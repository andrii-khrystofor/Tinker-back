using System;
using System.Collections.Generic;

namespace Tinker_Back.Models;

public partial class Contact
{
    public Contact(int firstUserId, int secondUserId)
    {
        FirstUserId = firstUserId;
        SecondUserId = secondUserId;
    }
    public int Id { get; set; }

    public int FirstUserId { get; set; }

    public int SecondUserId { get; set; }

    public virtual User? FirstUser { get; set; }

    public virtual User? SecondUser { get; set; }
}
