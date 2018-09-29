using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Attributes;

namespace ValidationService.UnitTests.TestObject
{
    public class User
    {
        [CustomRequired]
        public string UserId { get; set; }

        [CustomMinStringLength(3)]
        public string Name { get; set; }

        [CustomRange(18, 40)]
        public int Age { get; set; }

        public User(string userId, string name, int age)
        {
            UserId = userId;
            Name = name;
            Age = age;
        }
    }
}
