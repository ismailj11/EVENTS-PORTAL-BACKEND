using System;
using System.Collections.Generic;

namespace EP_DAL.Models;

public partial class Invitation
{
    public int InvitationId { get; set; }

    public int FkEventId { get; set; }

    public int FkUserId { get; set; }

    public bool? AttendanceStatus { get; set; }

    public DateTime? InvitedAt { get; set; }

    public string? Email { get; set; }

    public DateTime? AttendedAt { get; set; }

    public bool? IsScanned { get; set; }

    public string? Name { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
