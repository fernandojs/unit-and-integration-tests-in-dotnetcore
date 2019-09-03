
using Moq;
using Xunit;
using Simple_CRM.Domain;
using Simple_CRM.Infra.Data.Repositories.Interfaces;
using Simple_CRM.Application;
using FluentAssertions;
using Bogus;
using Bogus.DataSets;
using System.Linq;

namespace Simple_CRM.XUnitTest
{
    public class BusinessServiceTests
    {

        /// <summary>
        /// Example using Moq to test Add one Business to repository
        /// In this example you can see a simple test using Moq without other dependencies
        /// </summary>
        [Fact]
        public void BusinessRepository_GetBusiness_ShouldReturnUniqueBusiness()
        {
            // Arrange
            var business = new Business(1,
                                            "ACME SA",
                                            "",
                                            "",
                                            true);

            var repository = new Mock<IBusinessRepository>();

            repository.Setup(r => r.GetById(business.Id))
                                .Returns(business);

            var businessService = new BusinessService(repository.Object);

            // Act
            var businessRet = businessService.GetOne(business.Id);

            // Assert
            Assert.Equal(business, businessRet);
            repository.Verify(r => r.GetById(1), Times.Once);
        }


        /// <summary>
        /// Example using Moq to test Add one Business to repository
        /// In this example you can see a simple test using Moq with FluentAssertions
        /// </summary>
        [Fact]
        public void BusinessRepository_AddBusiness_ShouldAddAndReturnThisBusiness()
        {
            // Arrange
            var business = new Business(1,
                                        "ACME SA",
                                        "acme@sa.com",
                                        "www.acme.com",
                                        true);

            var repository = new Mock<IBusinessRepository>();

            repository.Setup(r => r.Add(business))
                                .Returns(business);

            var businessService = new BusinessService(repository.Object);

            // Act
            var businessRet = businessService.Add(business);

            // Assert
            Assert.True(businessRet);
            repository.Verify(r => r.Add(business), Times.Once);

            // Assert FluentAssertions
            businessRet.Should().Be(true);
        }

        /// <summary>
        /// Example using Moq to test Add one Business to repository
        /// In this example you can see a simple test using Moq with FluentAssertions and Bogus
        /// </summary>
        [Fact]
        public void BusinessRepository_GetAllBusiness_ShouldReturnAllBusiness()
        {
            // Arrange
            var businessId = 1;
            var businessList = new Faker<Business>("en")
                               .CustomInstantiator(
                                    f => new Business(
                                   businessId++,
                                   f.Name.FirstName(Name.Gender.Male),
                                   f.Internet.Email().ToLower(),
                                   f.Internet.Url().ToLower(),
                                   true
                                   )).Generate(50);

            var businessList2 = new Faker<Business>("en")
                               .CustomInstantiator(
                                    f => new Business(
                                   businessId++,
                                   f.Name.FirstName(Name.Gender.Male),
                                   f.Internet.Email().ToLower(),
                                   f.Internet.Url().ToLower(),
                                   false
                                   )).Generate(50);

            var finalBusinessList = businessList.Union(businessList2).AsQueryable();


            var repository = new Mock<IBusinessRepository>();

            repository.Setup(r => r.GetAll())
                                .Returns(finalBusinessList);

            var businessService = new BusinessService(repository.Object);

            // Act
            var businessRet = businessService.GetAllActive();
                      
            // Assert FluentAssertions
            businessRet.Should().HaveCount(c => c > 1).And.OnlyHaveUniqueItems();
            businessRet.Should().NotContain(c => !c.Status);
        }
    }
}
