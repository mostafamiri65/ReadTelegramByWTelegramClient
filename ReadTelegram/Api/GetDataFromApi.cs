using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ReadTelegram.Entities;
using System.Net.Http.Json;

namespace ReadTelegram.Api
{
    public class GetDataFromApi
    {
        TxtPrcContext context = new TxtPrcContext();
        public async Task<List<TelegramChannel>> GetChannels()
        {

            //HttpClient http = new HttpClient();
            //string getPath = "http://2.181.250.24:1101/GetChannels";
            //http.BaseAddress = new Uri(getPath);
            //List<TelegramChannel> channels = new List<TelegramChannel>();
            //HttpResponseMessage response = await http.GetAsync(getPath);
            //if (response.IsSuccessStatusCode)
            //{
            //    channels = await response.Content.ReadFromJsonAsync<List<TelegramChannel>>();
            //}
            var channels = await context.TelegramChannels.ToListAsync();
            return channels;
        }

        public async Task<long> MaxPostId(long telegramChannelId)
        {

            var max = await context.TelegramPosts.Where(p => p.TelegramChannelId == telegramChannelId)
                .OrderByDescending(p => p.PostId).ToListAsync();
            if (max.Count == 0)
            {
                return 0;
            }
            return max[0].PostId;
        }
    }
}
