using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace SchemaObjectMapper
{
    public class FixedWidthSchema<T> : ISchema
    {
        public FixedWidthSchema()
        {
            this.Mappings = new List<BaseMapping>();
        }

        public void AddMapping(Expression<Func<T, object>> expr, int startIndex, int length, bool trim = true)
        {
            this.Mappings.Add(new FixedWidthMapping<T>(expr, startIndex, length, trim));
        }

        public List<BaseMapping> Mappings { get; private set; }
    }
}