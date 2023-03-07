using System;
using System.Collections.Generic;

namespace Tinker_Back
{
    public partial class Chat
    {
        public Chat()
        {
            UserToChats = new HashSet<UserToChat>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsGroupChat { get; set; }
        public string? Description { get; set; }

        public virtual Message Message { get; set; } = null!;
        public virtual ICollection<UserToChat> UserToChats { get; set; }
    }
}
