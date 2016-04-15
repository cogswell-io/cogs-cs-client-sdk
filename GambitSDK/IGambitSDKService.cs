namespace GambitSDK
{
	using System;
	using System.Threading.Tasks;
	using Gambit.Data.Response;
	using GambitCore;
	using GambitData;

	public interface IGambitSDKService
	{
		/// <summary>
		/// Authenticates, validates and persists an incoming event
		/// </summary>
		/// <param name="eventModel"></param>
		/// <param name="secretKey"></param>
		/// <returns></returns>
		Task<Response<EventResponse>> EventAsync(
			EventModel eventModel,
			string secretKey);

		/// <summary>
		/// Establishes a websocket on which to receive push messages
		/// </summary>
		/// <param name="pushModel"></param>
		/// <param name="clientSecret"></param>
		/// <param name="action">declare callback that recieve message</param>
		SocketClient PushAsync(
			PushModel pushModel, 
			string clientSecret, 
			Action<MessageResponse> action = null);
		
		/// <summary>
		/// Fetches the identified message by its token and the namespace + CIID which authenticated.
		/// </summary>
		/// <param name="messageBody"></param>
		/// <param name="token"></param>
		/// <param name="accessKey"></param>
		/// <param name="clientSecret"></param>
		/// <returns></returns>
		Task<Response<string>> MessageAsync(
			MessageModel messageBody,
			string token,
			string accessKey,
			string clientSecret);

		/// <summary>
		/// Fetches the schema for a particular namespace
		/// </summary>
		/// <param name="name"></param>
		/// <param name="accessKey"></param>
		/// <param name="secretKey"></param>
		/// <returns></returns>
		Task<Response<NamespaceResponse>> NamespaceAsync(string name, string accessKey, string secretKey);
	}
}
