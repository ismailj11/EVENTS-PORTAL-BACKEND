using System;
using System.Collections.Generic;

namespace EP_DAL.Models;

public partial class EventRegistration
{
    public int RegistrationId { get; set; }

    public int FkEventId { get; set; }

    public int FkUserId { get; set; }

    public string? Status { get; set; }

    public DateTime? RegistredAt { get; set; }

    public bool? Attended { get; set; }

    public DateTime? CheckedInAt { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
