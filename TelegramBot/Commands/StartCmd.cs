using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Commands
{
    public class StartCmd : Command
    {
        public override string Name => "start";
        public override async void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            await client.SendTextMessageAsync(
                chatId,
                "Hey, What is up?"
                //replyMarkup: new InlineKeyboardMarkup(
                //    InlineKeyboardButton.WithUrl("Repository", "https://123t"))
                );

        }
    }
}
