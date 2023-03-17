using System;
using System.Collections.Generic;

namespace Tinker_Back.Models
{
    public class UserToChat
    {
        public int Id { get; set; }

        public int ChatId { get; set; }

        public int UserId { get; set; }

        public virtual Chat Chat { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
