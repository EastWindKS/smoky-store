using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public class HelloCmd : Command
    {
        public override string Name => "hello";
        public override async void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Hey, What is up?");
        }
    }
}
