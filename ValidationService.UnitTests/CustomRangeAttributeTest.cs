using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Attributes;

namespace ValidationService.UnitTests
{
    /// <summary>
    /// Сводное описание для CustomRangeAttributeTest
    /// </summary>
    [TestClass]
    public class CustomRangeAttributeTest
    {
        [TestMethod]
        public void IsValid_With_Null_Int()
        {
            object nullObj = null;
            var rngattr = new CustomRangeAttribute(3,10);
            Assert.IsTrue(rngattr.IsValid(nullObj));
        }

        [TestMethod]
        public void IsValid_With_Correct_Value()
        {
            object intObj = 8;
            var rngattr = new CustomRangeAttribute(3,10);
            Assert.IsTrue(rngattr.IsValid(intObj));
        }

        [TestMethod]
        public void IsValid_With_Incorrect_String()
        {
            object intObj = 2;
            var rngattr = new CustomRangeAttribute(3,10);
            Assert.IsFalse(rngattr.IsValid(intObj));
        }
    }
}
