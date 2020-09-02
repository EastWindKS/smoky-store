using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Args;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi;
using WebApi.Data;

namespace TelegramBot
{
    static class Program
    {
        
        public static TelegramBotClient client = Bot.Get();

        static void Main(string[] args)
        {
            client.OnMessage += OnMessage;
            client.OnCallbackQuery += OnCallBackAction;
            client.StartReceiving();
            
            
            Console.ReadKey();
        }
        private static void OnMessage(object sender, MessageEventArgs e)
        {
            var chatId = e.Message.Chat.Id;
            var commands = Bot.Commands;

            if (e.Message.Text != null)
            {
                foreach (var cmd in commands)
                {
                    if (cmd.Contains(e.Message.Text))
                    {
                        cmd.Execute(e.Message, client);
                    }
                }

            }

            Console.WriteLine(e.Message.Text);

        }
        private static void OnCallBackAction(object sender, CallbackQueryEventArgs e)
        {
            var callBackName = e.CallbackQuery.Data;
            var callBacks = Bot.CallBacks;
            foreach ( var callBack in callBacks)
            {
                if (callBack.Contains(callBackName))
                {
                    callBack.Execute(e.CallbackQuery.Message,client);
                }
            }
        }
    }
}
