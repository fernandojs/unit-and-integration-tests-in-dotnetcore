using Simple_CRM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Simple_CRM.XUnitTest
{
    public class BusinessTest
    {

        /// <summary>
        /// Example using Moq to test Add one Business to repository
        /// In this example you can see a simple test using Moq without other dependencies
        /// </summary>
        [Fact(DisplayName = "New Customer Valid")]
        [Trait("Business", "Business Tests")]
        public void Business_NewBusiness_ShoudBeReturnValid()
        {
            // Arrange
            var business = new Business(1,
                                        "ACME SA",
                                        "cto@acme.com",
                                        "",
                                        true);         

            // Act
            var businessValid = business.IsValid();

            // Assert
            Assert.True(businessValid);
            Assert.Equal(0, business.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New Customer Invalid")]
        [Trait("Business", "Business Tests")]
        public void Business_NewBusiness_ShoudBeReturnInvalid()
        {
            // Arrange
            var business = new Business(1,
                                        "",
                                        "",
                                        "",
                                        true);

            // Act
            var businessValid = business.IsValid();

            // Assert
            Assert.False(businessValid);
            Assert.NotEqual(0, business.ValidationResult.Errors.Count);
        }
    }
}
