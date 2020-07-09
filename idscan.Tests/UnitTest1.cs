using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using idscan.Controllers;
using idscan.Models;
using idscan.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace idscan.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ItShould_return_False_For_Field_IsDeleted_At_Contact()
        {
            // arrange
            var contact = new Contact();

            // act

            // assert
            Assert.False(contact.IsDeleted);
        }

        [TestMethod]
        public void ItShould_return_not_null_contact_object()
        {
            // arrange
            var expected = new Fixture()
                .Build<Contact>()
                .With(x=>x.Phone,"89513423537")
                .Create();
            var sut = new ProfileBuilder(expected);
            // act

            // assert
            Assert.NotNull(sut);
        }

    }
}
