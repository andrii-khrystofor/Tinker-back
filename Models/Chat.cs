using System;
using System.Collections.Generic;

namespace Tinker_Back.Models;

public partial class Chat
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsGroupChat { get; set; }

    public string? Description { get; set; }

    public bool? IsPinned { get; set; }

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<UserToChat> UserToChats { get; } = new List<UserToChat>();
}
