namespace GambitCore
{
    using System;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Gambit.Data.Response;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A class for implementation of the WebSocket client, used for sending and receiving message
    /// </summary>
    public class SocketClient
    {
        private static readonly UTF8Encoding Encoder = new UTF8Encoding();
        private readonly GambitSettings _settings;
        private ClientWebSocket webSocket;

        /// <summary>
        /// Constructor for initialization of the class
        /// </summary>
        /// <param name="settings">A GambitSettings instance. If not provided, the default settings will be used</param>
        public SocketClient(GambitSettings settings = null)
        {
            if (settings == null)
            {
                settings = GambitSettings.DefaultSettings;
            }

            _settings = settings;
        }

        /// <summary>
        /// Gets or sets the Action that should be executed when message is received
        /// </summary>
        public Action<MessageResponse> OnMessage { get; set; }

        /// <summary>
        /// Starts the WebSocket client
        /// </summary>
        /// <param name="uri">Url of the WebSocket to connect to</param>
        /// <param name="json">JSON-Base64 header value</param>
        /// <param name="payloadHMAC">Payload-HMAC header value</param>
        /// <returns></returns>
        public async Task Start(string uri, string json, string payloadHMAC)
        {
            var response = new Response<string>();

            try
            {
                if (webSocket == null)
                {
                    webSocket = new ClientWebSocket();
                }

                ClientWebSocketOptions option = webSocket.Options;
                option.SetRequestHeader("JSON-Base64", json);
                option.SetRequestHeader("Payload-HMAC", payloadHMAC);
                option.KeepAliveInterval = this._settings.DefaultMaxSessionIdleTimeout;

                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

                // await Send(this.webSocket);
                await Receive(this.webSocket);

                // this was the original code that made the socket go to the abort state after
                // the first message
                // await Task.WhenAll(Receive(webSocket), Send(webSocket));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
            }
        }

        /// <summary>
        /// Stops the web socket client
        /// </summary>
        public async Task Stop()
        {
            if (webSocket != null)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None);
                //webSocket.Dispose();
            }
        }

        /// <summary>
        /// Sends a message
        /// </summary>
        /// <param name="webSocket">A Web Socket where the message should be send</param>
        private async Task Send(ClientWebSocket webSocket)
        {
            byte[] buffer = new byte[] { (byte)0xFF };
            await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

            // What is the purpose of this cycle?
            while (webSocket.State == WebSocketState.Open)
            {
                await Task.Delay(_settings.DefaultMaxSessionIdleTimeout);
            }
        }

        /// <summary>
        /// Listenes for a message
        /// </summary>
        /// <param name="webSocket">Web Socket to listen from</param>
        private async Task Receive(ClientWebSocket webSocket)
        {
            while (webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = new byte[_settings.ReceivedChunkSize];

                try
                {
                    var result = await webSocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await
                            webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty,
                                CancellationToken.None);
                    }
                    else
                    {
                        string data = Encoder.GetString(buffer);
                        if (OnMessage != null)
                        {
                            //parse string to message
                            var messageResponse = JsonConvert.DeserializeObject<MessageResponse>(
                                data,
                                new JsonSerializerSettings()
                                {
                                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                                });

                            messageResponse.JsonData = JObject.Parse(data);

                            //Build ACK package
                            JObject json = new JObject();
                            json.Add("event", "message-received");
                            json.Add("message_id", messageResponse.MessageId);

                            var jsonString = JsonConvert.SerializeObject(json);
                            var encoded = Encoder.GetBytes(jsonString);
                            var msgBuffer = new ArraySegment<byte>(encoded, 0, encoded.Length);
                            await webSocket.SendAsync(msgBuffer, WebSocketMessageType.Text, true, CancellationToken.None);

                            OnMessage(messageResponse);
                        }
                    }
                }
                // Todo: Concrete exception handling
                catch (Exception err)
                {
                    if (OnMessage != null)
                    {
                        OnMessage(new MessageResponse
                        {
                            EventName = "ERROR DURING MESSAGE RECEIVE",
                            JsonData = JObject.FromObject(err)
                        });
                    }
                }
            }
        }
    }
}
