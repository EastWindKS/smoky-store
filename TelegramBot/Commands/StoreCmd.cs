using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Commands
{
    public class StoreCmd : Command
    {

        public override string Name { get; } = "store";

        public override void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var keyboard = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Tobaccos", "getTobaccoCompanies"),
                InlineKeyboardButton.WithCallbackData("Coal", "getCoalCompanies"),
               });
            client.SendTextMessageAsync(chatId, "Choose product", replyMarkup: keyboard);
        }
    }
}
