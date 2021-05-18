using Cmd.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace Cmd.Classes
{
    public class TelegramBot
    {
        private ITelegramBotClient client;
        
        public Func<string, string> OnCommand;

        public TelegramBot()
        {
            
            client = new TelegramBotClient(AppSettings.TelegramToken);

            client.OnMessage += OnMessage;
            client.StartReceiving();
        }

        private async void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                switch (e.Message.Type) 
                {
                    case MessageType.Text:
                        var newMesssage = OnCommand?.Invoke(e.Message.Text);
                        await client.SendTextMessageAsync(e.Message.Chat.Id, newMesssage);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
