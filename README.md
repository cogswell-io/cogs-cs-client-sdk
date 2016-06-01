# Cogs C# SDK


## Description
The Cogs SDK real-time message brokering system

## Requirements

* C# 5.0
* Visual Studio 12+

## [Installation] (#build-details)

### Manual
* Check out or download Cogs SDK
* Open gambit-sdk.sln in Visual Studio
* Restore NuGet packages
* Build Gambit.SDK target

## [Code Samples](#code-samples)
You will see the name Gambit throughout our code samples. This was the code name used for Cogs prior to release.

### Preparation for using the Client SDK

```cs
using Gambit.Data.Response;
using GambitCore;
using GambitData;
using GambitSDK;

// Hex encoded access-key from one of your api keys in the Web UI.
string accessKey = "your-access-key";

// Hex encoded client salt/secret pair acquired from /client_secret endpoint and
// associated with above access-key.
string clientSalt = "your-client-salt";
string clientSecret = "your-client-secret";

// Create and setup the Cogs SDK service
GambitSDKService cogsService = new GambitSDK.GambitSDKService();
```

### POST /event
This API route is used send an event to Cogs.

```cs

//Create an eventModel, this will store all information required for sending an event.
EventModel eventModel = new GambitData.EventModel();

//Set the eventModel client salt
eventModel.ClientSalt = clientSalt;

//Set the eventModel client secret
eventModel.ClientSalt = clientSecret;

//Set the eventModel access key
eventModel.AccessKey = accessKey;

//Set the event model's event name
eventModel.EventName = "EventExample";

//Select which Namespace this event pertains to. This Namespace will need
//to be defined in the Web UI.
eventModel.Namespace = "ExampleNamespace";

//Set the timestamp to be now.
eventModel.Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

//define an attributes dictionary. This should contain all primary key attributes and any
//Additional attributes you want to include in the event. If our namespace had email and
//full_name as the primary key, and an additional attribute called phone_number, our event
//Might look like this
Dictionary<string, object> attributes = new Dictionary<string, object>()
{
  { "email", "example@cogs.io" },
  { "full_name", "Bobby Jones" },
  { "phone_number", "5555555555" }
};

//set the attributes for the event model to these attributes.
eventModel.Attributes = attributes;

//send the event
Task<Response<EventResponse>> futureEventResponse = cogsService.EventAsync(eventModel, clientSecretKey);

//handle the event response
Response<EventResponse> eventResponse = await futureEventResponse;

if (eventResponse.IsSuccess)
{
  //handle success case
  Console.WriteLine("Event successfully sent!");
}
else
{
  //handle failure case
}

```

### GET /push
This API route is used to subscribe to a particular topic.

```cs
//Initialize the model which will store all the data necessary for subscribing.
PushModel subscribeModel = new GambitData.PushModel();

//Set the model client salt
subscribeModel.ClientSalt = clientSalt;

//set the model access key
subscribeModel.AccessKey = accessKey;

//Set the namespace which this model is using
subscribeModel.Namespace = "ExampleNamespace";

//Set the timestamp to be the current time in ISO format.
subscribeModel.Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

//Since we are using the same Namespace that we did in the Event example, we can use the same attributes as well.
//Even though the attributes includes an attribute that is not part of the primary key it will still accept it and
//be able to subscribe.
subscribeModel.Attributes = attributes;

//Here is defined what action will take place in the event a message is received.
Action<MessageResponse> action = (MessageResponse) =>
{
  //Do some action using the data you have received from a message

  //the namespace from which you received a message should always be provided
  Console.WriteLine("Message namespace:" + MessageResponse.Namespace)

  //This will not always be populated, it is depending on the content you filled out for your campaign, for example the JSON
  //body will appear here if it was supplied. The data will be a JSON string which will need to be parsed.
  Console.WriteLine("Message Data:" + MessageResponse.Data)

  //Another example of a message parameter that will not always be present. But if you selected the option to forward the
  //event that triggered the campaign during campaign creation this will be populated. This parameter is also a JSON string
  //that will need to be parsed
  Console.WriteLine("Event which triggered message sending:" + MessageResponse.ForwardedEvent)
};

//The actual request that creates the websocket and subscribes to the topic defined in the attributes provided in the
//subscribeModel variable.
cogsService.PushAsync(subscribeModel, clientSecretKey, action);
```

## License

Copyright 2016 Aviata Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
