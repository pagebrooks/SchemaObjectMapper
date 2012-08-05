using System.Linq;
using System.Collections.Generic;
using System;

namespace SchemaObjectMapper
{
    public interface ISchema
    {
        List<BaseMapping> Mappings { get; }
    }
}