# Introduction

Easily map delimited and fixed-width strings to objects.

### Basic Usage

```c#
// Create Schema
var personSchema = new DelimitedSchema<Person>();
personSchema.AddMapping(p => p.FirstName, 0);
personSchema.AddMapping(p => p.LastName, 1);
personSchema.AddMapping(p => p.Gender, 2);
personSchema.AddMapping(p => p.DateOfBirth, 3);

// Create Mapper
var personMapper = new DelimitedSchemaObjectMapper<Person>(personSchema, "|");

// Map Lines
var person = personMapper.MapLine("Foo|Bar|M|01/02/2003");

Assert.AreEqual("Foo", person.FirstName);
Assert.AreEqual("Bar", person.LastName);
Assert.AreEqual("M", person.Gender);
Assert.AreEqual(DateTime.Parse("01/02/2003"), person.DateOfBirth);
```