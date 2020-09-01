using System;
using System.Collections.Generic;
using Telegram.Bot;
using TelegramBot.Commands;

namespace TelegramBot
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private const string Token = "1348175102:AAHz5ZCLU0Fs-GMX59ZhxiuNMQgNeIG-704";
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();


        public static TelegramBotClient Get()
        {
            if (_client != null)
            {
                return _client;
            }

            _client = new TelegramBotClient(Token) { Timeout = TimeSpan.FromSeconds(5) };
            commandsList = new List<Command> { new HelloCmd() };

            return _client;
        }
    }
}
