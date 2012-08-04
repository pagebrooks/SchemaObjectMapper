using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace SchemaObjectMapper
{
    public class DelimitedSchema<T> : ISchema<T>
    {
        public DelimitedSchema()
        {
            this.Mappings = new List<BaseMapping<T>>();
        }

        public void AddMapping(Expression<Func<T, object>> expr, int ordinal)
        {
            this.Mappings.Add(new DelimitedMapping<T>(expr, ordinal));
        }

        public List<BaseMapping<T>> Mappings { get; private set; }
    }
}