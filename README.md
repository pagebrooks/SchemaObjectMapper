# Introduction

Easily map delimited and fixed-width strings to objects.

### Basic Usage (Delimited Lines)

```c#
// Create schema
var personSchema = new DelimitedSchema<Person>();
personSchema.AddMapping(p => p.FirstName, 0);
personSchema.AddMapping(p => p.LastName, 1);
personSchema.AddMapping(p => p.Gender, 2);
personSchema.AddMapping(p => p.DateOfBirth, 3);

// Create mapper
var personMapper = new DelimitedSchemaObjectMapper<Person>(personSchema, "|");

// Map line
var person = personMapper.MapLine("Foo|Bar|M|01/02/2003");

Assert.AreEqual("Foo", person.FirstName);
Assert.AreEqual("Bar", person.LastName);
Assert.AreEqual("M", person.Gender);
Assert.AreEqual(DateTime.Parse("01/02/2003"), person.DateOfBirth);
```


### Basic Usage (Fixed-Width Lines)

```c#
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
```