using System;
using System.Collections.Generic;

namespace Tinker_Back.Models
{
    public class Message
    {
        public Message(string text, DateTime timeSent, int senderId, int chatId)
        {
            Text = text;
            SentTime = timeSent;
            SenderId = senderId;
            ChatId = chatId;
        }
        public int Id { get; set; }

        public string Text { get; set; }

        public int SenderId { get; set; }
        public int? RepliesToMessageId { get; set; }

        public DateTime SentTime { get; set; }

        public bool? isSeen { get; set; }

        public bool? IsPinned { get; set; }

        public int ChatId { get; set; }

        public bool? isForwarded { get; set; }

        public virtual Chat Chat { get; set; } = null!;

        public virtual User Sender { get; set; } = null!;
    }
}
