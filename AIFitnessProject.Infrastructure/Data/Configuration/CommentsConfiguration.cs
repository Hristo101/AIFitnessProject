using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.IdentityModel.Tokens;
using AIFitnessProject.Infrastructure.Common;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class CommentsConfiguration : IEntityTypeConfiguration<UserComment>
    {

        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.HasData(SeedComments());
        }

        private List<UserComment> SeedComments()
        {
            

            UserComment comment;
            List<UserComment> userComments = new List<UserComment>();
            comment = new UserComment()
            {
                Id = 1,
                Content = "Светослав е прекрасен треньор,който благодарение на него хората постигат своето мечтано тяло.Препоръчвам задължително!",
                Rating = 5,
                ReceiverId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                SenderId = "0a2830ef-8be3-4ef6-910b-33b680d659d3"
            };

            userComments.Add(comment);

            comment = new UserComment()
            {
                Id = 2,
                Content = "Невероятен треньор.Изключително прецизен в работата си,с изключително добро държание,с него можете да постигенте всичко",
                Rating = 5,
                ReceiverId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                SenderId = "cd87d0e2-4047-473e-924a-3e10406c5583"
            };

            userComments.Add(comment);

            return userComments;
        }


    }
}
