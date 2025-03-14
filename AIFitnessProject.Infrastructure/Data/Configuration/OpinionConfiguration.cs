﻿using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasData(SeedOpinion());
        }
        private List<Opinion> SeedOpinion()
        {
            Opinion opinion;
            List<Opinion> opinions = new List<Opinion>();

            opinion = new Opinion()
            {
                Id = 1,
                SenderId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                Content = "Работя с тази компания от няколко месеца и съм изключително доволен от подкрепата и ресурсите, които ми предоставят. Приложението е мощно и интуитивно, което ми позволява да предоставям персонализирани тренировъчни планове на моите клиенти и да следя техния напредък в реално време. Също така, екипът осигурява отлични условия за професионално развитие и редовно ни мотивират да постигаме още по-добри резултати. Заплащането е конкурентно и редовно, като винаги се чувствам оценен за усилията, които влагам в работата си. Гордея се, че съм част от този екип и се надявам да продължим да растем заедно.",
                Rating = 5,
            };

            opinions.Add(opinion);

            opinion = new Opinion()
            {
                Id = 2,
                SenderId = "0e136956-3e82-4e00-8f60-b274cdf40833",
                Content = "Работя с тази компания от около половин година и съм изключително благодарна за възможността да бъда част от екипа. Приложението е изключително удобно и лесно за използване, като ми дава възможност да създавам и персонализирам тренировъчни планове за моите клиенти. Отношението на компанията към нас, като треньори, е безупречно – получавам постоянно обучение и подкрепа, което ми помага да бъда още по-добра в това, което правя. Заплащането е справедливо и винаги се чувствам оценена за труда си. Най-хубавото е, че работя с екип, който има ясна визия и ценности, които съвпадат с моите. Препоръчвам горещо тази компания за всички, които искат да се развиват в професията си и да се чувстват част от нещо голямо.",
                Rating = 5,
            };

            opinions.Add(opinion);

            opinion = new Opinion()
            {
                Id = 3,
                SenderId = "0c4c8519-6a0a-45a5-acc2-64c0de9af4a8",
                Content = "Работя в тази компания от близо година и съм изключително доволна от професионалните условия, които предлага. Заплащането е конкурентно и се актуализира редовно според резултатите и усилията ми. Работната атмосфера е подкрепяща, а екипът винаги е готов да помогне, когато срещна предизвикателства. Най-голямото предимство за мен е достъпът до постоянни обучения, които ми помагат да бъда в крак с новостите в диетологията.",
                Rating = 5,
            };

            opinions.Add(opinion);

            opinion = new Opinion()
            {
                Id = 4,
                SenderId = "0e0e4964-6fa8-43ef-b6ba-a8722a1d5708",
                Content = "Условията тук са едни от най-добрите в индустрията – модерна платформа, която улеснява работата ми, и отличен баланс между натоварване и заплащане. Заплащането е не само мотивиращо, но също така включва бонуси за постигане на цели. Допълнително, екипът е невероятно сплотен и винаги готов да сподели опит и съвети.\r\n",
                Rating = 5,
            };

            opinions.Add(opinion);

            return opinions;
        }
    }
}
