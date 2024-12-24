using System;
using System.Collections.Generic;

namespace EP_DAL.Models;

public partial class Userwithevent
{
    public int UserwitheventId { get; set; }

    public int FkUserId { get; set; }

    public int FkEventId { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
