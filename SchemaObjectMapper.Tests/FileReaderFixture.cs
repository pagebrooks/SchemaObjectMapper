using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace SchemaObjectMapper.Tests
{
    [TestFixture]
    public class FileReaderFixture
    {
        [SetUp]
        public void Setup()
        {
            var lines = new List<string>
            { 
                "P|Foo|Bar|M|1/2/2003", 
                "P|John|Smith|M|1/2/2003", 
                "P|Jane|Smith|F|1/2/1980" 
            };
            File.WriteAllLines("text.txt", lines);
        }

        [TearDown]
        public void TearDown()
        {
            if(File.Exists("text.txt"))
            {
                File.Delete("text.txt");
            }
        }

        [Test]
        public void FileReader_ReadFile_Enumerates_Each_Line()
        {
            var schema = new DelimitedSchema<Person>();
            schema.AddMapping(s => s.FirstName, 1);
            schema.AddMapping(s => s.LastName, 2);
            schema.AddMapping(s => s.Gender, 3);
            schema.AddMapping(s => s.DateOfBirth, 4);

            var mapper = new DelimitedSchemaObjectMapper<Person>(schema, "|");
            var persons = new List<Person>();

            var fr = new FileReader();
            fr.ReadFile("text.txt", line =>
            {
                if (line.StartsWith("P"))
                {
                    persons.Add(mapper.MapLine(line));
                }
            });

            Assert.AreEqual(3, persons.Count);
        }
    }
}
