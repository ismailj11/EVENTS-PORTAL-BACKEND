using System;
using System.Collections.Generic;

namespace EP_DAL.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public DateTime Date { get; set; }

    public int MaxAttendees { get; set; }

    public DateTime CreatedAt { get; set; }

    public int FkOrganizerId { get; set; }

    public string Location { get; set; } = null!;

    public string Category { get; set; } = null!;

    public bool? RequiresTicket { get; set; }

    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

    public virtual User FkOrganizer { get; set; } = null!;

    public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Userwithevent> Userwithevents { get; set; } = new List<Userwithevent>();
}
