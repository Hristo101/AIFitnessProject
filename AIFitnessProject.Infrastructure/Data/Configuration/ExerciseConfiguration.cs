using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIFitnessProject.Infrastructure.Data.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(SeedExercises());
        }

        private List<Exercise> SeedExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                    Id = 1,
                    Name = "Лицеви опори",
                    Description = "Упражнение за гърди, рамене и трицепс.",
                    ImageUrl = "https://training.fit/wp-content/uploads/2020/02/liegestuetze.png",
                    VideoUrl = "https://www.youtube.com/watch?v=k11CvzGtRGE",
                    Series = 4,
                    Repetitions = 10,
                    MuscleGroup = "Гърди",
                    CreatedById = 2,
                    DifficultyLevel = "Лесно"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Лежанка",
                    Description = "Упражнение за средната част на гърдите.",
                    ImageUrl = "https://4fitness.bg/blog/Files/Images/exercises/close-grip-bench-press.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=hWbUlkb5Ms4",
                    MuscleGroup = "Гърди",
                    Series = 3,
                    Repetitions = 10,
                      CreatedById = 2,
                    DifficultyLevel = "Средно"
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Кофички",
                    Description = "Упражнение за долната част на гърдите.",
                    ImageUrl = "https://4fitness.bg/blog/Files/Images/exercises/dips-exercise.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=m_sGDGxlibI",
                    MuscleGroup = "Гърди",
                    Series = 3,
                    Repetitions = 8,
                      CreatedById = 2,
                    DifficultyLevel = "Средно"
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Флайс",
                    Description = "Упражнение за средната част на гърдите.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/28/399_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=GhG-UXc2v1Y",
                    MuscleGroup = "Гърди",
                    Series = 3,
                    Repetitions = 8,
                      CreatedById = 2,
                    DifficultyLevel = "Лесно",
                },
                   new Exercise
                {
                    Id = 5,
                    Name = "Мъртва тяга",
                    Description = "Упражнение за цялата част на гърба.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/65_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=yPqv3ejnZvc",
                    MuscleGroup = "Гръб",
                    Series = 3,
                    Repetitions = 10,
                      CreatedById = 2,
                    DifficultyLevel = "Трудно",
                   },
                     new Exercise
                {
                    Id = 6,
                    Name = "Горен скрипец с широк хват",
                    Description = "Упражнение за широкия гръбен мускул.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/392_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=_HsCxLNPpoY",
                    Series = 4,
                    Repetitions = 12,
                    MuscleGroup = "Гръб",
                      CreatedById = 2,
                    DifficultyLevel = "Лесно",
                   },
                new Exercise
                {
                    Id = 7,
                    Name = "Вертикален скрипец с тесен хват",
                    Description = "Упражнение за средната и долната част на гърба.",
                    ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/403_M.png",
                    VideoUrl = "https://www.youtube.com/watch?v=LWBxwyp9zJg",
                    Series = 3,
                    Repetitions = 10,
                    MuscleGroup = "Гръб",
                      CreatedById = 2,
                    DifficultyLevel = "Лесно",
                },
                  new Exercise
                {
                    Id = 8,
                    Name = "Дърпане на дъмбел с една ръка",
                    Description = "Упражнението основно натоварва средната и долната част на гърба, но също така ангажира и горната част като стабилизиращ фактор.\r\n\r\n1. Средна част на гърба (Mid-Back)\r\nРомбовидни мускули (Rhomboids) – Осигуряват стабилност на лопатките и спомагат за добрата стойка.\r\nСредна част на трапецовидния мускул (Middle Trapezius) – Участва в свиването на лопатките при дърпането.\r\n2. Долна част на гърба (Lower Back)\r\nШирок гръбен мускул (Latissimus Dorsi – Lats) – Основният мускул, отговорен за дебелината и ширината на гърба.\r\nЕректорите на гръбначния стълб (Erector Spinae) – Помагат за стабилизацията на тялото по време на движението.\r\n3. Горна част на гърба (Upper Back) – второстепенно натоварване\r\nГорна част на трапецовидния мускул (Upper Trapezius) – Не е основен мускул в движението, но подпомага стабилността.\r\nЗадно рамо (Posterior Deltoid) – Участва в движението, но с по-малка натовареност.\r\n",
                    ImageUrl = "https://fitnesdieta.com/images/uprajneniya/darpane-dumbbell.webp",
                    VideoUrl = "https://www.youtube.com/watch?v=3ff-qVskb-U",
                     Series = 3,
                    Repetitions = 10,
                    MuscleGroup = "Гръб",
                      CreatedById = 2,
                    DifficultyLevel = "Средно",
                },
                  new Exercise
                  {
                      Id = 9,
                      Name = "Римска тяга с лост",
                      Description = "Римската тяга основно натоварва задното бедро (хамстринги), седалищните мускули (глутеуси) и еректорите на гръбначния стълб. Второстепенно участват прасците, трапецът и предмишниците.",
                      ImageUrl = "https://4fitness.bg/blog/Files/Images/exercises/rimska-tqga.jpg",
                      VideoUrl = "https://www.youtube.com/watch?v=9MfK_wio48o",
                      Series = 4,
                      Repetitions = 12,
                      MuscleGroup = "Крака",
                        CreatedById = 2,
                      DifficultyLevel = "Трудно"
                  },
                       new Exercise
                  {
                      Id = 10,
                      Name = "Напади с дъмбели",
                      Description = "Нападите с дъмбели основно натоварват квадрицепсите, седалищните мускули и задното бедро. Второстепенно участват прасците, коремните мускули и стабилизаторите на тялото.",
                      ImageUrl = "https://fitnesdieta.com/images/uprajneniya/napadi-dumbbell.webp",
                      VideoUrl = "https://www.youtube.com/watch?v=5VnSY1HG3gE",
                      Series = 3,
                      Repetitions = 10,
                      MuscleGroup = "Крака",
                        CreatedById = 2,
                      DifficultyLevel = "Трудно"
                  },
                  new Exercise
                  {
                      Id = 11,
                      Name = "Клек с щанга",
                      Description = "Клекът с щанга основно натоварва квадрицепсите, седалищните мускули и задното бедро. Второстепенно участват еректорите на гръбначния стълб, прасците, коремните мускули и аддукторите.",
                      ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/26/159_M.png",
                      VideoUrl = "https://www.youtube.com/watch?v=LhwTU5VQVc4",
                      Series = 4,
                      Repetitions = 12,
                      MuscleGroup = "Крака",
                        CreatedById = 2,
                      DifficultyLevel = "Средно",
                  },
                  new Exercise
                  {
                      Id = 12,
                      Name = "Преден клек",
                      Description ="Предният клек основно натоварва квадрицепсите, седалищните мускули и задното бедро. Той също така активно включва ядрени мускули като коремните мускули и еректорите на гръбначния стълб, тъй като те стабилизират тялото. Поради позицията на щангата, натоварването върху коленете и горната част на бедрата е по-голямо в сравнение с традиционния клек.",
                      ImageUrl = "https://www.mybodycreator.com/content/files/2023/05/25/181_M.png",
                      VideoUrl = "https://www.youtube.com/watch?v=AMezBp0JPOs",
                      Series = 3,
                      Repetitions = 10,
                      MuscleGroup = "Крака",
                        CreatedById = 2,
                      DifficultyLevel = "Средно"
                  },
                  new Exercise
                  {
                      Id = 13,
                      Name = "Лег Преса",
                      Description ="Лег пресата основно натоварва квадрицепсите, седалищните мускули и задното бедро. Второстепенно се включват прасците и аддукторите. Позицията на краката на платформата може да променя акцента върху различните мускулни групи, като по-широкото разположение на краката натоварва повече вътрешната част на бедрата.",
                      ImageUrl = "https://static.vecteezy.com/ti/vetor-gratis/p1/15708604-homem-fazendo-exercicio-de-leg-press-na-maquina-ilustracaoial-plana-isolada-no-fundo-branco-vetor.jpg",
                      VideoUrl = "https://www.youtube.com/watch?v=hYyPQkrOsJs",
                      Series = 3,
                      Repetitions = 10,
                      MuscleGroup = "Крака",
                        CreatedById = 2,
                      DifficultyLevel = "Лесно"
                  },
                  new Exercise
                  {
                     Id = 14,
                     Name = "Екстензии за предно бедро",
                     Description = "Екстензиите за предно бедро основно натоварват квадрицепсите, като акцентът е върху правия бедрен мускул. Второстепенно могат да се активират и мускулите на бедрото като страничните части на квадрицепсите, в зависимост от позицията на краката. Тази упражнение е много ефективно за изолация на предната част на бедрата.",
                     ImageUrl = "https://i0.wp.com/muscu-street-et-crossfit.fr/wp-content/uploads/2022/09/Muscles-Leg-Extension.001.jpeg?resize=1024%2C576&ssl=1",
                     VideoUrl = "https://www.youtube.com/watch?v=uo9nJ8V13Ys",
                     Series = 4,
                     Repetitions = 12,
                     MuscleGroup = "Крака",
                       CreatedById = 2,
                     DifficultyLevel = "Лесно"
                  },
                  new Exercise
                  {
                      Id = 15,
                      Name ="Екстензии за задно бедро",
                      ImageUrl = "https://knockoutbg.com/wp-content/uploads/2022/10/mashina-zadno-bedro-evolve-leg-curl-ec-015-1.jpg",
                      VideoUrl = "https://www.youtube.com/watch?v=pey4eP2-PRw",
                      Series = 4,
                      Repetitions = 12,
                      Description = "Сгъване за задно бедро – основно натоварва хамстрингите (задната част на бедрото). Включват се и седалищните мускули в зависимост от амплитудата на движението.",
                      DifficultyLevel = "Лесно",
                        CreatedById = 2,
                      MuscleGroup = "Крака",
                  },
                  new Exercise
                  {
                      Id = 16,
                      ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOTSS_jxjKXyZSlClKwR6ugHui3cx5OPJX0Q&s",
                      Name ="Сгъване на адуктори",
                      VideoUrl = "https://www.youtube.com/shorts/RNRgMox8xwE",
                      Series = 3,
                      Repetitions = 10,
                      Description = "Сгъването на адуктори на машина се изпълнява, като седнеш на специализирана машина със странични подложки за бедрата. Краката са разтворени и поставени на подложките, след което ги приближаваш една към друга, като напрягаш вътрешната част на бедрата. Това упражнение активно натоварва адукторите, които са мускулите на вътрешната част на бедрата.",
                      DifficultyLevel = "Лесно",
                        CreatedById = 2,
                      MuscleGroup = "Крака"
                  },
                  new Exercise
                  {
                      Id = 17,
                      ImageUrl = "https://hercules.bg/wp-content/uploads/2020/10/bulgarian-split-squat.jpg",
                      Name = "Български клек",
                      VideoUrl = "https://www.youtube.com/watch?v=CChuXbuB3XU",
                      Description = "Българският клек се изпълнява с един крак на стъпало или пейка, а другият е в изправено положение. При спускането се извършва клякане с единия крак, докато другият остава на място. Това упражнение натоварва квадрицепсите, седалищните мускули и задното бедро, като включва и стабилизаторите на тялото.",
                      DifficultyLevel = "Трудно",
                      MuscleGroup = "Крака",
                      Repetitions = 8,
                        CreatedById = 2,
                      Series = 3,
                  },
                  new Exercise
                  {
                      Id = 18,
                      ImageUrl ="https://i0.wp.com/www.muscleandfitness.com/wp-content/uploads/2018/04/wall-ball-1109.jpg?quality=86&strip=all",
                      Name = "Топка към стена",
                      Description = "Упражнението „топка към стена“ включва клякане и хвърляне на медицинска топка към стена. Изпълняваш клек, избутваш топката с ръце към стената и след това я хващаш и повтаряш. То натоварва квадрицепсите, седалището, раменете и ядрото.",
                      DifficultyLevel = "Средно",
                      MuscleGroup = "Крака",
                      Repetitions = 4,
                       CreatedById = 2,
                      Series = 15,
                      VideoUrl = "https://www.youtube.com/watch?v=ZRO2yxaibc0",
                  }

            };
         }
    } 
}
