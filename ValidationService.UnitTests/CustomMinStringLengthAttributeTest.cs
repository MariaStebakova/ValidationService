using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Attributes;

namespace ValidationService.UnitTests
{
    /// <summary>
    /// Сводное описание для CustomMinStringLengthAttributeTest
    /// </summary>
    [TestClass]
    public class CustomMinStringLengthAttributeTest
    {
        [TestMethod]
        public void IsValid_With_Null_String()
        {
            object nullObj = null;
            var strattr = new CustomMinStringLengthAttribute(3);
            Assert.IsTrue(strattr.IsValid(nullObj));
        }

        [TestMethod]
        public void IsValid_With_Correct_String()
        {
            object stringObj = "test";
            var strattr = new CustomMinStringLengthAttribute(3);
            Assert.IsTrue(strattr.IsValid(stringObj));
        }

        [TestMethod]
        public void IsValid_With_Incorrect_String()
        {
            object stringObj = "no";
            var strattr = new CustomMinStringLengthAttribute(3);
            Assert.IsFalse(strattr.IsValid(stringObj));
        }
    }
}
