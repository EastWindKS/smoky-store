using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebApi.Models;


namespace TelegramBot.CallBacks
{
    public class GetTobaccoCompaniesCallBack : CallBack
    {
        public override string Name { get; } = "getTobaccoCompanies";
        private const string Url = "http://localhost:63042/api/companies";

        public override async void Execute(Message msg, TelegramBotClient client)
        {
            using var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.GetAsync(Url);
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();

                List<Company> tmp = JsonConvert.DeserializeObject<List<Company>>(result);
                foreach (var item in tmp)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
        }

    }
}
