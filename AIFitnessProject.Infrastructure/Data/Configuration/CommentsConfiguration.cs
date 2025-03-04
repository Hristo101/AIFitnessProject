using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            comment = new UserComment()
            {
                Id = 3,
                Content = "Страхотна диетоложка - хранителният ми режим никога не е бил по-вкусен и ефективен.",
                Rating = 5,
                ReceiverId = "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                SenderId = "0a2830ef-8be3-4ef6-910b-33b680d659d3"
            };

            userComments.Add(comment);

            comment = new UserComment()
            {
                Id = 4,
                Content = "Експерт в покачването на мускулна маса!Диетата,която изготви,е ефективна и лесна за спазване.",
                Rating = 5,
                ReceiverId = "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                SenderId = "cd87d0e2-4047-473e-924a-3e10406c5583"
            };
            
            userComments.Add(comment);

            return userComments;
        }


    }
}
