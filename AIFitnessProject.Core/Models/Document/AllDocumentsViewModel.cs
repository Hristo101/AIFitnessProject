using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFitnessProject.Core.Models.Document
{
    public class AllDocumentsViewModel
    {
        public int Id { get; set; }
        public byte[] ProfilePictureUrl { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;
    }
}
