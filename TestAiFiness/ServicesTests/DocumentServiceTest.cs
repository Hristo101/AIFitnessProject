using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Document;
using AIFitnessProject.Core.Services;
using AIFitnessProject.Infrastructure.Common;
using AIFitnessProject.Infrastructure.Data;
using AIFitnessProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAiFiness.ServicesTests
{
    [TestFixture]
    public class DocumentServiceTest
    {
        private IRepository repository;
        private IDocumentService documentService;
        private ApplicationDbContext applicationDbContext;
        private Mock<UserManager<ApplicationUser>> userManagerMock;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("HouseDB_" + Guid.NewGuid())
                .Options;
            applicationDbContext = new ApplicationDbContext(contextOptions, false);
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
            repository = new Repository(applicationDbContext);

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
            userManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());
            userManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            documentService = new DocumentService(repository, userManagerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }

        [Test]
        public async Task SendDocumentsAsync_ShouldAddDocumentToRepository()
        {
    
            var userId = "testuser1";
            var user = new ApplicationUser
            {
                Id = userId,
                UserName = "testuser1@example.com",
                Email = "testuser1@example.com",
                FirstName = "Test",
                LastName = "User"
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var model = new SendDocumentsViewModel
            {
                Position = "Trainer",
                Bio = "Test Bio",
                ExperienceYears = 5,
                CertificationDetails = "Test Certification Details",
                Specialization = "Test Specialization"
            };

            var mockFile = new Mock<IFormFile>();
            var content = "Fake file content";
            var fileName = "test.jpg";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            mockFile.Setup(_ => _.OpenReadStream()).Returns(ms);
            mockFile.Setup(_ => _.FileName).Returns(fileName);
            mockFile.Setup(_ => _.Length).Returns(ms.Length);
            model.CertificateImage = mockFile.Object;

         
            await documentService.SendDocumentsAsync(userId, model);


            var documents = await repository.AllAsReadOnly<Document>().ToListAsync();
            Assert.That(documents.Count, Is.EqualTo(1));
            Assert.That(documents[0].UserId, Is.EqualTo(userId));
            Assert.That(documents[0].Position, Is.EqualTo(model.Position));
            Assert.That(documents[0].Bio, Is.EqualTo(model.Bio));
            Assert.That(documents[0].ExperienceYears, Is.EqualTo(model.ExperienceYears));
            Assert.That(documents[0].SertificationDetails, Is.EqualTo(model.CertificationDetails));
            Assert.That(documents[0].Specialization, Is.EqualTo(model.Specialization));
            Assert.That(documents[0].IsAccept, Is.False);
            Assert.That(documents[0].SertificateImage, Is.Not.Null);
        }

        [Test]
        public async Task AllDocumentsInAdmin_ShouldReturnAllUnacceptedDocuments()
        {
        
            var user1 = new ApplicationUser
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile1.jpg"
            };

            var user2 = new ApplicationUser
            {
                Id = "user2",
                FirstName = "Jane",
                LastName = "Smith",
                ProfilePicture = "profile2.jpg"
            };

            await repository.AddAsync(user1);
            await repository.AddAsync(user2);

            var document1 = new Document
            {
                Id = 1,
                UserId = "user1",
                User = user1,
                Position = "Trainer",
                Specialization = "Weight Training",
                IsAccept = false,
                Bio = "Test Bio 1",
                ExperienceYears = 3,
                SertificationDetails = "Cert 1",
                SertificateImage = "image1.jpg"
            };

            var document2 = new Document
            {
                Id = 2,
                UserId = "user2",
                User = user2,
                Position = "Dietitian",
                Specialization = "Vegan Nutrition",
                IsAccept = false,
                Bio = "Test Bio 2",
                ExperienceYears = 5,
                SertificationDetails = "Cert 2",
                SertificateImage = "image2.jpg"
            };

            var document3 = new Document
            {
                Id = 3,
                UserId = "user1",
                User = user1,
                Position = "Trainer",
                Specialization = "Cardio",
                IsAccept = true, 
                Bio = "Test Bio 3",
                ExperienceYears = 7,
                SertificationDetails = "Cert 3",
                SertificateImage = "image3.jpg"
            };

            await repository.AddAsync(document1);
            await repository.AddAsync(document2);
            await repository.AddAsync(document3);
            await repository.SaveChangesAsync();

            
            var result = await documentService.AllDocumentsInAdmin();

           
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(d => d.Id == 3), Is.False, "Accepted document should not be in the results");

            var doc1 = result.FirstOrDefault(d => d.Id == 1);
            Assert.That(doc1, Is.Not.Null);
            Assert.That(doc1.FirstName, Is.EqualTo("John"));
            Assert.That(doc1.LastName, Is.EqualTo("Doe"));
            Assert.That(doc1.Position, Is.EqualTo("Trainer"));
            Assert.That(doc1.Specialization, Is.EqualTo("Weight Training"));
            Assert.That(doc1.ProfilePictureUrl, Is.EqualTo("profile1.jpg"));

            var doc2 = result.FirstOrDefault(d => d.Id == 2);
            Assert.That(doc2, Is.Not.Null);
            Assert.That(doc2.FirstName, Is.EqualTo("Jane"));
            Assert.That(doc2.LastName, Is.EqualTo("Smith"));
            Assert.That(doc2.Position, Is.EqualTo("Dietitian"));
            Assert.That(doc2.Specialization, Is.EqualTo("Vegan Nutrition"));
            Assert.That(doc2.ProfilePictureUrl, Is.EqualTo("profile2.jpg"));
        }

        [Test]
        public async Task DetailsDocumentsInAdmin_ShouldReturnCorrectDocument()
        {
         
            var user = new ApplicationUser
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile1.jpg"
            };

            await repository.AddAsync(user);

            var document = new Document
            {
                Id = 1,
                UserId = "user1",
                User = user,
                Position = "Trainer",
                Specialization = "Weight Training",
                IsAccept = false,
                Bio = "Test Bio 1",
                ExperienceYears = 3,
                SertificationDetails = "Cert 1",
                SertificateImage = "image1.jpg"
            };

            await repository.AddAsync(document);
            await repository.SaveChangesAsync();

            
            var result = await documentService.DetailsDocumentsInAdmin(1);

           
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.Position, Is.EqualTo("Trainer"));
            Assert.That(result.Specialization, Is.EqualTo("Weight Training"));
            Assert.That(result.Bio, Is.EqualTo("Test Bio 1"));
            Assert.That(result.ExperienceYears, Is.EqualTo(3));
            Assert.That(result.CertificationDetails, Is.EqualTo("Cert 1"));
            Assert.That(result.CertificateImage, Is.EqualTo("image1.jpg"));
            Assert.That(result.ProfilePicture, Is.EqualTo("profile1.jpg"));
        }

        [Test]
        public async Task ConfirmModel_ShouldReturnCorrectDocumentViewModel()
        {
          
            var user = new ApplicationUser
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe",
                ProfilePicture = "profile1.jpg"
            };

            await repository.AddAsync(user);

            var document = new Document
            {
                Id = 1,
                UserId = "user1",
                User = user,
                Position = "Trainer",
                Specialization = "Weight Training",
                IsAccept = false,
                Bio = "Test Bio 1",
                ExperienceYears = 3,
                SertificationDetails = "Cert 1",
                SertificateImage = "image1.jpg"
            };

            await repository.AddAsync(document);
            await repository.SaveChangesAsync();

          
            var result = await documentService.ConfirmModel(1);

         
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.Position, Is.EqualTo("Trainer"));
            Assert.That(result.Specialization, Is.EqualTo("Weight Training"));
            Assert.That(result.ProfilePictureUrl, Is.EqualTo("profile1.jpg"));
        }

        [Test]
        public async Task Delete_ShouldRemoveDocumentAndReturnTrue()
        {
         
            var document = new Document
            {
                Id = 1,
                UserId = "user1",
                Position = "Trainer",
                Specialization = "Weight Training",
                IsAccept = false,
                Bio = "Test Bio 1",
                ExperienceYears = 3,
                SertificationDetails = "Cert 1",
                SertificateImage = "image1.jpg"
            };

            await repository.AddAsync(document);
            await repository.SaveChangesAsync();

            
            var result = await documentService.Delete(1);

           
            Assert.That(result, Is.True);
            var documents = await repository.AllAsReadOnly<Document>().ToListAsync();
            Assert.That(documents.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task Accept_ShouldCreateTrainerAndAssignRoleWhenPositionIsTrainer()
        {
      
            var user = new ApplicationUser
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe"
            };
            await repository.AddAsync(user);

            var document = new Document
            {
                Id = 1,
                UserId = "user1",
                User = user,
                Position = "Trainer",
                Specialization = "Weight Training",
                IsAccept = false,
                Bio = "Test Bio 1",
                ExperienceYears = 3,
                SertificationDetails = "Cert 1",
                SertificateImage = "image1.jpg"
            };
            await repository.AddAsync(document);
            await repository.SaveChangesAsync();

 
            userManagerMock
                .Setup(x => x.FindByIdAsync(user.Id))
                .ReturnsAsync(user);

   
            userManagerMock
                .Setup(x => x.AddToRoleAsync(
                    It.Is<ApplicationUser>(u => u.Id == user.Id),
                    It.Is<string>(r => r == "Trainer")))
                .ReturnsAsync(IdentityResult.Success);


            var result = await documentService.Accept(1);


            Assert.That(result, Is.True);

            var updatedDocument = await repository.AllAsReadOnly<Document>()
                .FirstAsync(d => d.Id == 1);
            Assert.That(updatedDocument.IsAccept, Is.True);

            var trainer = await repository.AllAsReadOnly<Trainer>()
                .FirstOrDefaultAsync(t => t.UserId == "user1");
            Assert.That(trainer, Is.Not.Null);
            Assert.That(trainer.Specialization, Is.EqualTo("Weight Training"));
            Assert.That(trainer.Bio, Is.EqualTo("Test Bio 1"));
            Assert.That(trainer.Experience, Is.EqualTo(3));
            Assert.That(trainer.SertificationDetails, Is.EqualTo("Cert 1"));
            Assert.That(trainer.SertificateImage, Is.EqualTo("image1.jpg"));


            userManagerMock.Verify(x => x.AddToRoleAsync(
                It.Is<ApplicationUser>(u => u.Id == user.Id),
                It.Is<string>(r => r == "Trainer")),
                Times.Once);
        }

        [Test]
        public async Task Accept_ShouldCreateDietitianAndAssignRoleWhenPositionIsDietitian()
        {

            var user = new ApplicationUser
            {
                Id = "user1",
                FirstName = "John",
                LastName = "Doe"
            };
            await repository.AddAsync(user);

            var document = new Document
            {
                Id = 1,
                UserId = "user1",
                User = user,
                Position = "Dietitian",
                Specialization = "Vegan Nutrition",
                IsAccept = false,
                Bio = "Test Bio 1",
                ExperienceYears = 3,
                SertificationDetails = "Cert 1",
                SertificateImage = "image1.jpg"
            };
            await repository.AddAsync(document);
            await repository.SaveChangesAsync();


            userManagerMock
                .Setup(x => x.FindByIdAsync(user.Id))
                .ReturnsAsync(user);

            userManagerMock
                .Setup(x => x.AddToRoleAsync(
                    It.Is<ApplicationUser>(u => u.Id == user.Id),
                    It.Is<string>(r => r == "Dietitian")))
                .ReturnsAsync(IdentityResult.Success);

            var result = await documentService.Accept(1);

            Assert.That(result, Is.True);

            var updatedDocument = await repository.AllAsReadOnly<Document>()
                .FirstAsync(d => d.Id == 1);
            Assert.That(updatedDocument.IsAccept, Is.True);

            var dietitian = await repository.AllAsReadOnly<Dietitian>()
                .FirstOrDefaultAsync(d => d.UserId == "user1");
            Assert.That(dietitian, Is.Not.Null);
            Assert.That(dietitian.Specialization, Is.EqualTo("Vegan Nutrition"));
            Assert.That(dietitian.Bio, Is.EqualTo("Test Bio 1"));
            Assert.That(dietitian.Experience, Is.EqualTo(3));
            Assert.That(dietitian.SertificationDetails, Is.EqualTo("Cert 1"));
            Assert.That(dietitian.SertificateImage, Is.EqualTo("image1.jpg"));

            userManagerMock.Verify(x => x.AddToRoleAsync(
                It.Is<ApplicationUser>(u => u.Id == user.Id),
                It.Is<string>(r => r == "Dietitian")),
                Times.Once);
        }
    }
}