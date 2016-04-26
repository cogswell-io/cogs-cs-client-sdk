namespace GambitSDK
{
	using System;
	using System.Threading.Tasks;
	using Gambit.Data.Response;
	using GambitCore;
	using GambitData;

    /// <summary>
    /// Interface for the GambitSDKService
    /// </summary>
	public interface IGambitSDKService
	{
		/// <summary>
		/// Authenticates, validates and persists an incoming event
		/// </summary>
		/// <param name="eventModel">The incoming event</param>
		/// <param name="secretKey">Secret key for authentication</param>
		/// <returns>Event response</returns>
		Task<Response<EventResponse>> EventAsync(
			EventModel eventModel,
			string secretKey);

		/// <summary>
		/// Establishes a websocket on which to receive push messages
		/// </summary>
		/// <param name="pushModel">Data to push</param>
		/// <param name="clientSecret">Client secret key</param>
		/// <param name="action">Declare callback that recieve message</param>
		SocketClient PushAsync(
			PushModel pushModel, 
			string clientSecret, 
			Action<MessageResponse> action = null);
		
		/// <summary>
		/// Fetches the identified message by its token and the namespace + CIID which authenticated.
		/// </summary>
		/// <param name="messageBody">Message to be send</param>
		/// <param name="token">Token of the message</param>
		/// <param name="accessKey">Access key</param>
		/// <param name="clientSecret">Client secret</param>
		/// <returns>MessageResponse</returns>
		Task<Response<string>> MessageAsync(
			MessageModel messageBody,
			string token,
			string accessKey,
			string clientSecret);

		/// <summary>
		/// Fetches the schema for a particular namespace
		/// </summary>
		/// <param name="name">Name of the namespace that should be retreived</param>
		/// <param name="accessKey">Access key</param>
		/// <param name="secretKey">Secret key</param>
		/// <returns>Returns namespace schema details</returns>
		Task<Response<NamespaceResponse>> NamespaceAsync(string name, string accessKey, string secretKey);
	}
}
