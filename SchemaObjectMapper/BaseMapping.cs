using System.Linq;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace SchemaObjectMapper
{
    public abstract class BaseMapping
    {
        public PropertyInfo PropertyInfo { get; set; }
    }
}