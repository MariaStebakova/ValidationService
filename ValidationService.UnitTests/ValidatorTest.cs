using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation.Validator;
using ValidationService.UnitTests.TestObject;

namespace ValidationService.UnitTests
{
    /// <summary>
    /// Сводное описание для ValidatorTest
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void Validate_With_Correct_User()
        {
            User user = new User("7845", "Maria", 20);

            Validator<User> userValidator = new Validator<User>();
            ValidationResult result = userValidator.Validate(user);

            int expectedErrorsCount = 0;
            int actualErrorsCount = result.ValidationErrors.Count;

            Assert.AreEqual(expectedErrorsCount, actualErrorsCount);
        }

        [TestMethod]
        public void Validate_With_Incorrect_User_1ex()
        {
            User person = new User(null, "Maria", 20);

            Validator<User> personValidation = new Validator<User>();
            ValidationResult result = personValidation.Validate(person);

            int expectedErrorsCount = 1;
            int actualErrorsCount = result.ValidationErrors.Count;

            Assert.AreEqual(expectedErrorsCount, actualErrorsCount);
        }

        [TestMethod]
        public void Validate_With_Incorrect_User_2ex()
        {
            User person = new User(null, "Maria", 10);

            Validator<User> personValidation = new Validator<User>();
            ValidationResult result = personValidation.Validate(person);

            int expectedErrorsCount = 2;
            int actualErrorsCount = result.ValidationErrors.Count;

            Assert.AreEqual(expectedErrorsCount, actualErrorsCount);
        }

        [TestMethod]
        public void Validate_With_Incorrect_User_3ex()
        {
            User person = new User(null, "Ma", 10);

            Validator<User> personValidation = new Validator<User>();
            ValidationResult result = personValidation.Validate(person);

            int expectedErrorsCount = 3;
            int actualErrorsCount = result.ValidationErrors.Count;

            Assert.AreEqual(expectedErrorsCount, actualErrorsCount);
        }

        [TestMethod]
        public void Validate_With_Null_Logger()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Validator<User>(null));
        }
    }
}
