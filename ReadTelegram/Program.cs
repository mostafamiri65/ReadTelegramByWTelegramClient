using ReadTelegram.Api;
using ReadTelegram.Entities;
using TL;
using Message = TL.Message;

//string apiKey = "6559355316:AAEQDAW59SzoHlwKSVSF5W2tg4VvMrYseNo";
//string channelName = "@mizenaft";

//var bot = new TelegramBotClient(apiKey);
//long channelId = -100123456789;
//var channelMessages = await bot.GetChatAsync(channelName);
#region Login InTelegram
Console.BackgroundColor = ConsoleColor.Yellow;
Thread.Sleep(1000);
Console.BackgroundColor = ConsoleColor.White;
Thread.Sleep(1000);
Console.BackgroundColor = ConsoleColor.Green;
Thread.Sleep(1000);
Console.BackgroundColor = ConsoleColor.White;

var client = new WTelegram.Client();
var myself = await client.LoginUserIfNeeded();

var chats = await client.Messages_GetAllChats();

#endregion


while (true)
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Black;
        #region Get Channels
        GetDataFromApi getAPI = new GetDataFromApi();
        var channels = await getAPI.GetChannels();

        #endregion

        #region Save Data
        foreach (var channel in channels)
        {
            var last = await getAPI.MaxPostId(channel.Id);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Max Pst Id in channel : " + channel.TelegramChannelName + " is : " + last);
            Thread.Sleep(5000);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("System read " + channel.TelegramChannelName + " channel");
            InputPeer peer = chats.chats[channel.TelegramChannelId]; // the chat (or User) we want

            for (int offset_id = 0; ;)
            {
                var messages2 = await client.Messages_GetHistory(peer, offset_id);
                if (messages2.Messages.Length == 0) break;
                foreach (var msgBase in messages2.Messages)
                {
                    var from = messages2.UserOrChat(msgBase.From ?? msgBase.Peer); // from can be User/Chat/Channel
                    if (msgBase is Message msg)
                    {
                        TelegramPost post = new TelegramPost();

                        post.TelegramChannelId = channel.Id;
                        post.PostViews = msg.views;
                        post.PostContent = msg.message;
                        post.PostDate = msg.date.ToString();
                        post.PostEditedDate = msg.edit_date.ToString();
                        post.PostForwards = msg.forwards;
                        post.PostId = Convert.ToInt64(msg.ID);
                        post.PostUsername = from.MainUsername;
                        post.CreateDate = DateTime.Now;
                        DateTime date = Convert.ToDateTime(post.PostDate);
                        if (date < DateTime.Now.AddDays(-20))
                            break;
                        if (post.PostId > last)
                        {
                            try
                            {
                                PostDataToApi postApi = new PostDataToApi();
                                await postApi.PostAsync(post);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("System Save " + post.PostId + " with " + post.PostViews + " views");
                                //if (await postApi.CheckForExisting(post.PostId, post.TelegramChannelId))
                                //{
                                //    Console.BackgroundColor = ConsoleColor.White;
                                //    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                //    Console.WriteLine("All Before Posts is saved");
                                //    Console.BackgroundColor = ConsoleColor.Black;
                                //    break;
                                //}

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error occourd ... " + ex);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (msgBase is MessageService ms)
                        Console.WriteLine($"{from} [{ms.action.GetType().Name[13..]}]");
                }
                offset_id = messages2.Messages[^1].ID;
            }
            Thread.Sleep(4 * 60 * 1000);

        }
        #endregion

    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
  

}



