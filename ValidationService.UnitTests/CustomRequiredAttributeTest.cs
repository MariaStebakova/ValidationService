using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Attributes;

namespace ValidationService.UnitTests
{
    /// <summary>
    /// Сводное описание для MyRequiredAttributeTest
    /// </summary>
    [TestClass]
    public class CustomRequiredAttributeTest
    {

        [TestMethod]
        public void IsValid_With_Null()
        {
            object nullObj = null;
            var rqdattr = new CustomRequiredAttribute();
            Assert.IsFalse(rqdattr.IsValid(nullObj));
        }

        [TestMethod]
        public void IsValid_With_Not_Null()
        {
            object notNullObj = "test";
            var rqdattr = new CustomRequiredAttribute();
            Assert.IsTrue(rqdattr.IsValid(notNullObj));
        }
    }
}
