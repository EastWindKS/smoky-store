using System;
using System.Collections.Generic;
using Telegram.Bot;
using TelegramBot.Commands;

namespace TelegramBot
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static readonly  string Token = AppSettings.AppSettings.Key;
        private static List<Command> _commandsList;
        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();


        public static TelegramBotClient Get()
        {
            if (_client != null)
            {
                return _client;
            }

            _client = new TelegramBotClient(Token) { Timeout = TimeSpan.FromSeconds(5) };
            _commandsList = new List<Command> { new StartCmd() };

            return _client;
        }
    }
}
