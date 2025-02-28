﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Calendar
{
    public class MealCalendarViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Calories { get; set; }

        public int MealCount { get; set; }

        public string MealTime { get; set; }

        public DateOnly Date { get; set; } // Добавяме дата за събитието

        public TimeOnly StartEventTime { get; set; } // Начало на събитието

        public TimeOnly EndEventTime { get; set; } // Край на събитието

        public int CalendarId { get; set; } // ID на календара
    }
}
