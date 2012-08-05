using System.Linq;
using System.Collections.Generic;
using System;

namespace SchemaObjectMapper
{
    public interface ISchemaObjectMapper<out T> where T : new()
    {
        T MapLine(string line);
    }
}