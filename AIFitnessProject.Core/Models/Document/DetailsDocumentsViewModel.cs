using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Document
{
    public class DetailsDocumentsViewModel
    {
        public string Position { get; set; } = string.Empty;

        public byte[] ProfilePicture { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int ExperienceYears { get; set; }

        public byte[] CertificateImage { get; set; }

        public string Bio { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public string CertificationDetails { get; set; } = string.Empty;
    }
}
