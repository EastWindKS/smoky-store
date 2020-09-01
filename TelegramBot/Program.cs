using System;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace TelegramBot
{
    static class Program
    {
        public static TelegramBotClient client = Bot.Get();

        static void Main(string[] args)
        {
            client.OnMessage += OnMessage;
            client.StartReceiving();
            Console.ReadKey();
        }
        private static async void OnMessage(object sender, MessageEventArgs e)
        {
            var chatId = e.Message.Chat.Id;
            var commands = Bot.Commands;
            foreach (var cmd in commands)
            {
                if (cmd.Contains(e.Message.Text))
                {
                    cmd.Execute(e.Message,client);
                }
            }

            Console.WriteLine(e.Message.Text);

        }
    }
}
