#r "Newtonsoft.Json"
using System;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Text;
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
    string deviceID = "";
    string messageString = "led";
    var connectionString = GetEnvironmentVariable("AZURE_IOTHUB");
    ServiceClient serviceClient;
    serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
    var commandMessage = new Message(Encoding.ASCII.GetBytes(messageString));
    await serviceClient.SendAsync(deviceID, commandMessage);
    return req.CreateResponse(HttpStatusCode.OK);
}

public static string GetEnvironmentVariable(string name)
{
    return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
}