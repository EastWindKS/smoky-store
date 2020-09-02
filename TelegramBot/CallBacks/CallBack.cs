using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.CallBacks
{
    public abstract class CallBack
    {
        public abstract string Name { get; }
        public abstract void Execute(Message msg, TelegramBotClient client);
        public bool Contains(string callBack)
        {
            return callBack.Contains(this.Name);
        }
    }
}
