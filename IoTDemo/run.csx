#r "Microsoft.Azure.NotificationHubs"
#r "Newtonsoft.Json"

using System;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;

public static async void Run(string myEventHubMessage, IAsyncCollector<Notification> notification, TraceWriter log)
{
    log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");

    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    string gcmNotificationPayload = "{\"data\": {\"message\": \"Demo (" + 
                                        myEventHubMessage + ")\" }}";
    log.Info($"{gcmNotificationPayload}");
    await notification.AddAsync(new GcmNotification(gcmNotificationPayload));
}