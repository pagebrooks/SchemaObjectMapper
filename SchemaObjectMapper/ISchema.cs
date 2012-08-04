using System.Linq;
using System.Collections.Generic;
using System;

namespace SchemaObjectMapper
{
    public interface ISchema<T>
    {
        List<BaseMapping<T>> Mappings { get; }
    }
}