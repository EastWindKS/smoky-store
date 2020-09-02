using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Commands
{
    public class StartCmd : Command
    {
        public override string Name => "start";

        private string sendMsg = "You can use commands: \n/store,\n/contacts,\n/about";
        public override async void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            await client.SendTextMessageAsync(chatId, sendMsg);
        }
    }
}
