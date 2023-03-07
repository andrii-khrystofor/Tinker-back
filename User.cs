using System;
using System.Collections.Generic;

namespace Tinker_Back
{
    public partial class User
    {
        public User()
        {
            ContactFirstUsers = new HashSet<Contact>();
            ContactSecondUsers = new HashSet<Contact>();
            UserToChats = new HashSet<UserToChat>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual Message Message { get; set; } = null!;
        public virtual ICollection<Contact> ContactFirstUsers { get; set; }
        public virtual ICollection<Contact> ContactSecondUsers { get; set; }
        public virtual ICollection<UserToChat> UserToChats { get; set; }
    }
}
