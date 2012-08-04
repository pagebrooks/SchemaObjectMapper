using System.Linq;
using System.Collections.Generic;
using System;

namespace SchemaObjectMapper.Tests
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}