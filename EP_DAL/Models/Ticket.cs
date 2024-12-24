using System;
using System.Collections.Generic;

namespace EP_DAL.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int FkEventId { get; set; }

    public int FkUserId { get; set; }

    public string TicketType { get; set; } = null!;

    public decimal Price { get; set; }

    public bool IsCheckedIn { get; set; }

    public DateTime PurchasedAt { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
