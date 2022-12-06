﻿using Azure;
using Azure.Messaging.EventGrid;
using System;
using System.Threading.Tasks;
public class Program
{
    private const string topicEndpoint = "https://hrtopicrahulrahul.eastus-1.eventgrid.azure.net/api/events";
    private const string topicKey = "c6KMP+NaKuQj6o6V+TIeIAojjuyLG8/ZL5f/FKRg5X4=";
    public static async Task Main(string[] args)
    {
        Uri endpoint = new Uri(topicEndpoint);
        AzureKeyCredential credential = new AzureKeyCredential(topicKey);
        EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);
        EventGridEvent firstEvent = new EventGridEvent(
        subject: $"New Employee: Alba Sutton",
        eventType: "Employees.Registration.New",
        dataVersion: "1.0",
        data: new
        {
            FullName = "Alba Sutton",
            Address = "4567 Pine Avenue, Edison, WA 97202"
        }
     );
        EventGridEvent secondEvent = new EventGridEvent(
               subject: $"New Employee: Alexandre Doyon",
               eventType: "Employees.Registration.New",
               dataVersion: "1.0",
               data: new
               {
                   FullName = "Alexandre Doyon",
                   Address = "456 College Street, Bow, WA 98107"
               }
           );
        await client.SendEventAsync(firstEvent);
        Console.WriteLine("First event published");
        await client.SendEventAsync(secondEvent);
        Console.WriteLine("Second event published");
    }
}