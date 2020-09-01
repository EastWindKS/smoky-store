using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Message msg, TelegramBotClient client);

        public bool Contains(string cmd)
        {
            return cmd.Contains(this.Name);
        }
    }
}
