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
personSchema.AddMapping(p => p.FirstName, 0, 10, trim: true);
personSchema.AddMapping(p => p.LastName, 10, 10, trim: true);
personSchema.AddMapping(p => p.Gender, 24, 1, trim: true);
personSchema.AddMapping(p => p.DateOfBirth, 25, 10, trim: true);

// Create mapper
var mapper = new FixedWidthSchemaObjectMapper<Person>(personSchema);

// Map line
var person = mapper.MapLine("Foo       Bar           M01/02/2003");

Assert.AreEqual("Foo", person.FirstName);
Assert.AreEqual("Bar", person.LastName);
Assert.AreEqual("M", person.Gender);
Assert.AreEqual(DateTime.Parse("01/02/2003"), person.DateOfBirth);
```

### Basic Usage (FileReader)

```c#
var schema = new DelimitedSchema<Person>();
schema.AddMapping(s => s.FirstName, 1);
schema.AddMapping(s => s.LastName, 2);
schema.AddMapping(s => s.Gender, 3);
schema.AddMapping(s => s.DateOfBirth, 4);

var mapper = new DelimitedSchemaObjectMapper<Person>(schema, "|");
var persons = new List<Person>();

var fr = new FileReader();
fr.ReadFile("test.txt", line =>
{
	if (line.StartsWith("P"))
	{
		persons.Add(mapper.MapLine(line));
	}
});
```