using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SchemaObjectMapper.Tests
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class Charge
    {
        public double ChargeAmount { get; set; }
        public int Units { get; set; }
        public string Code { get; set; }
    }

    [TestFixture]
    public class SchemaObjectMapperFixture
    {
        [Test]
        public void DelimitedSchemaMapping_Properly_Maps_Delimited_Strings()
        {
            // Create Schema
            var patientSchema = new DelimitedSchema<Patient>();
            patientSchema.AddMapping(p => p.FirstName, 0);
            patientSchema.AddMapping(p => p.LastName, 1);
            patientSchema.AddMapping(p => p.Gender, 2);
            patientSchema.AddMapping(p => p.DateOfBirth, 3);

            var chargeSchema = new DelimitedSchema<Charge>();
            chargeSchema.AddMapping(c => c.Code, 0);
            chargeSchema.AddMapping(c => c.Units, 1);
            chargeSchema.AddMapping(c => c.ChargeAmount, 2);

            // Create Mapper
            var patientMapper = new DelimitedSchemaObjectMapper<Patient>(patientSchema, "|");
            var chargeMapper = new DelimitedSchemaObjectMapper<Charge>(chargeSchema, "|");

            // Map Lines
            var patient = patientMapper.MapLine("Foo|Bar|M|01/02/2003");
            var charge = chargeMapper.MapLine("12345|1|89.93");

            Assert.AreEqual("Foo", patient.FirstName);
            Assert.AreEqual("Bar", patient.LastName);
            Assert.AreEqual("M", patient.Gender);
            Assert.AreEqual(DateTime.Parse("01/02/2003"), patient.DateOfBirth);

            Assert.AreEqual("12345", charge.Code);
            Assert.AreEqual(1, charge.Units);
            Assert.AreEqual(89.93m, charge.ChargeAmount);
        }
        
        [Test]
        public void FixedWidthSchemaMapping_Properly_Maps_Fixed_Width_Strings()
        {
            var patientSchema = new FixedWidthSchema<Patient>();
            patientSchema.AddMapping(p => p.FirstName, 0, 10);
            patientSchema.AddMapping(p => p.LastName, 10, 10);
            patientSchema.AddMapping(p => p.Gender, 24, 1);
            patientSchema.AddMapping(p => p.DateOfBirth, 25, 10);

            var mapper = new FixedWidthSchemaObjectMapper<Patient>(patientSchema);
            var patient = mapper.MapLine("Foo       Bar           M01/02/2003");

            Assert.AreEqual("Foo", patient.FirstName);
            Assert.AreEqual("Bar", patient.LastName);
            Assert.AreEqual("M", patient.Gender);
            Assert.AreEqual(DateTime.Parse("01/02/2003"), patient.DateOfBirth);
        }
    }
}
