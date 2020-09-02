using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBot.CallBacks;
using TelegramBot.Commands;
using WebApi.Data;
using  Microsoft.Extensions.DependencyInjection;

namespace TelegramBot
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static readonly string Token = AppSettings.Key;
        private static List<Command> _commandsList;
        private static List<CallBack> _callBacksList;
       
        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();
        public static IReadOnlyList<CallBack> CallBacks => _callBacksList.AsReadOnly();

        
        public static TelegramBotClient Get()
        {
            
            if (_client != null)
            {
                return _client;
            }
            _client = new TelegramBotClient(Token) { Timeout = TimeSpan.FromSeconds(5) };
            _commandsList = new List<Command> { new StartCmd(), new StoreCmd() };
            _callBacksList = new List<CallBack> { new GetTobaccoCompaniesCallBack() };

            return _client;
        }
    }
}
