using EP_BLL.Dto.MarkAttendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_BLL.Services.MarkAttendance
{
    public interface IMarkAttendanceService
    {
        Task UpdateAttendanceStatusAsync(MarkAttendanceDto markAttendanceDto);
    }
}
