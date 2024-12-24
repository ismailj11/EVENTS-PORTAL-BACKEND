using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Dto.Events
{
    public class EventDto
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

    }
}
