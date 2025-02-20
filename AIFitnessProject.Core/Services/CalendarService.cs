using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Calendar;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IRepository repository;

        public CalendarService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async  Task<UserCalendarViewModel> GetModeForUserCalendar(string userId)
        {
           var model = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(x =>x.Id == userId)
                .Select(x => new UserCalendarViewModel()
                {
                    Email = x.Email,
                    FullName = x.FirstName + " " + x.LastName,
                    ProfilePictureUrl = x.ProfilePicture,
                }).FirstOrDefaultAsync();

            return model;
        }
    }
}
