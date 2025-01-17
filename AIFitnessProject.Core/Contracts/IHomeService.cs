﻿using AIFitnessProject.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetModelsForHomePageAsync();
    }
}
