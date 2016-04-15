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

    public class SocketClient
    {
        static readonly UTF8Encoding Encoder = new UTF8Encoding();

        private readonly GambitSettings _settings;
        private ClientWebSocket webSocket;

        public SocketClient(GambitSettings settings = null)
        {
            if (settings == null)
            {
                settings = GambitSettings.DefaultSettings;
            }
            _settings = settings;
        }

        public Action<MessageResponse> OnMessage { get; set; }

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

        public async Task Stop()
        {
            if (webSocket != null)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None);
                //webSocket.Dispose();
            }
        }

        // What is the purpose of this method?
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
                            var message = JsonConvert.DeserializeObject<MessageResponse>(
                                data,
                                new JsonSerializerSettings()
                                {
                                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                                });

                            //Build ACK package
                            JObject json = new JObject();
                            json.Add("event", "message-received");
                            json.Add("message_id", message.MessageId);

                            var jsonString = JsonConvert.SerializeObject(json);
                            var encoded = Encoder.GetBytes(jsonString);
                            var msgBuffer = new ArraySegment<byte>(encoded, 0, encoded.Length);
                            await webSocket.SendAsync(msgBuffer, WebSocketMessageType.Text, true, CancellationToken.None);

                            OnMessage(message);
                        }
                    }

                }
                // Todo: Concrete exception handling
                catch (Exception e)
                {
                    var err = e;
                    if (OnMessage != null)
                    {
                        OnMessage(new MessageResponse
                        {
                            EventName = "ERROR DURING MESSAGE RECEIVE",
                            MessageId = err.Message
                        });
                    }
                }
            }
        }
    }
}
