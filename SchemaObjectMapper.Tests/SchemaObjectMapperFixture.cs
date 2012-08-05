using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SchemaObjectMapper.Tests
{
    [TestFixture]
    public class SchemaObjectMapperFixture
    {
        [Test]
        public void DelimitedSchemaMapping_Properly_Maps_Delimited_Strings()
        {
            // Create Schema
            var personSchema = new DelimitedSchema<Person>();
            personSchema.AddMapping(p => p.FirstName, 0);
            personSchema.AddMapping(p => p.LastName, 1);
            personSchema.AddMapping(p => p.Gender, 2);
            personSchema.AddMapping(p => p.DateOfBirth, 3);

            var chargeSchema = new DelimitedSchema<Charge>();
            chargeSchema.AddMapping(c => c.Code, 0);
            chargeSchema.AddMapping(c => c.Units, 1);
            chargeSchema.AddMapping(c => c.ChargeAmount, 2);

            // Create Mapper
            var personMapper = new DelimitedSchemaObjectMapper<Person>(personSchema, "|");
            var chargeMapper = new DelimitedSchemaObjectMapper<Charge>(chargeSchema, "|");

            // Map lines
            var person = personMapper.MapLine("Foo|Bar|M|01/02/2003");
            var charge = chargeMapper.MapLine("12345|1|89.93");

            Assert.AreEqual("Foo", person.FirstName);
            Assert.AreEqual("Bar", person.LastName);
            Assert.AreEqual("M", person.Gender);
            Assert.AreEqual(DateTime.Parse("01/02/2003"), person.DateOfBirth);

            Assert.AreEqual("12345", charge.Code);
            Assert.AreEqual(1, charge.Units);
            Assert.AreEqual(89.93m, charge.ChargeAmount);
        }
        
        [Test]
        public void FixedWidthSchemaMapping_Properly_Maps_Fixed_Width_Strings()
        {
            // Create schema
            var personSchema = new FixedWidthSchema<Person>();
            personSchema.AddMapping(p => p.FirstName, 0, 10);
            personSchema.AddMapping(p => p.LastName, 10, 10);
            personSchema.AddMapping(p => p.Gender, 24, 1);
            personSchema.AddMapping(p => p.DateOfBirth, 25, 10);

            // Create mapper
            var mapper = new FixedWidthSchemaObjectMapper<Person>(personSchema);
            
            // Map line
            var person = mapper.MapLine("Foo       Bar           M01/02/2003");

            Assert.AreEqual("Foo", person.FirstName);
            Assert.AreEqual("Bar", person.LastName);
            Assert.AreEqual("M", person.Gender);
            Assert.AreEqual(DateTime.Parse("01/02/2003"), person.DateOfBirth);
        }
    }
}
