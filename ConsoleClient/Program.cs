using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleClient;

public class Program
{
    static HubConnection connection;

    public static async Task Main()
    {
        connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5200/messageHub")
                .Build();

        await connection.StartAsync();
        await connection.InvokeAsync("SendMessage", "Manolito", "what's up");

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}-> {message}");
        });

        Console.ReadLine();
    }
}

