using System;
using System.Collections.Generic;

namespace Tinker_Back.Models
{

    public class User
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Contact> ContactFirstUsers { get; } = new List<Contact>();

        public virtual ICollection<Contact> ContactSecondUsers { get; } = new List<Contact>();

        public virtual ICollection<Message> Messages { get; } = new List<Message>();

        public virtual ICollection<UserToChat> UserToChats { get; } = new List<UserToChat>();
    }
}