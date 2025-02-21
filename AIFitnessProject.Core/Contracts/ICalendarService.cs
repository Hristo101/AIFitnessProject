using AIFitnessProject.Core.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface ICalendarService
    {
        Task<UserCalendarViewModel> GetModeForUserCalendar(string userId);
    }
}
