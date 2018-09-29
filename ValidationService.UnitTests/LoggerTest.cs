using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Validation.Validator;
using ValidationService.UnitTests.TestObject;
using Logging;

namespace ValidationService.UnitTests
{
    /// <summary>
    /// Summary description for LoggerTest
    /// </summary>
    [TestClass]
    public class LoggerTest
    {

        [TestMethod]
        public void LoggerWritesData()
        {
            var loggerMock = new Mock<ILogger>();

            var service = new Validator<User>(loggerMock.Object);

            var obj = new User("1234", "El", 10);
            var result = service.Validate(obj);

            loggerMock.Verify(logger => logger.Warn(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
