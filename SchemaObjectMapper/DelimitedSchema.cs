using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace SchemaObjectMapper
{
    public class DelimitedSchema<T> : ISchema
    {
        public DelimitedSchema()
        {
            this.Mappings = new List<BaseMapping>();
        }

        public void AddMapping(Expression<Func<T, object>> expr, int ordinal)
        {
            this.Mappings.Add(new DelimitedMapping<T>(expr, ordinal));
        }

        public List<BaseMapping> Mappings { get; private set; }
    }
}