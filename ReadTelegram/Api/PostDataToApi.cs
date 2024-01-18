using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ReadTelegram.Entities;

namespace ReadTelegram.Api
{
    public class PostDataToApi
    {
        TxtPrcContext context = new TxtPrcContext();

        //private readonly HttpClient _httpClient = new HttpClient();
        //string url = "http://2.181.250.24:1101/CreatePost";

        public async Task PostAsync(TelegramPost post)
        {
            //var isexist = await context.TelegramPosts.AnyAsync(a=>a.PostId == post.PostId && 
            //a.TelegramChannelId == post.TelegramChannelId);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("A new Post");
           
                await context.AddAsync(post);
                await context.SaveChangesAsync();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("A new Post Saved ..");
            
          
        }
        public async Task<bool> CheckForExisting(long postId, long channelId)
        {
          return  await context.TelegramPosts.AnyAsync(a => a.PostId == postId &&
            a.TelegramChannelId == channelId);
        }
    }
}
