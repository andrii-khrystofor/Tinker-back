using System;
using System.Collections.Generic;

namespace Tinker_Back
{
    public partial class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int SenderId { get; set; }
        public byte[]? SentTime { get; set; }
        public bool? IsPinned { get; set; }
        public int ChatId { get; set; }

        public virtual User Id1 { get; set; } = null!;
        public virtual Chat IdNavigation { get; set; } = null!;
    }
}
