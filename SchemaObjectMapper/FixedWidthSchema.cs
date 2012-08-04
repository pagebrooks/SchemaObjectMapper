using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace SchemaObjectMapper
{
    public class FixedWidthSchema<T> : ISchema<T>
    {
        public FixedWidthSchema()
        {
            this.Mappings = new List<BaseMapping<T>>();
        }

        public void AddMapping(Expression<Func<T, object>> expr, int startIndex, int length, bool trim = true)
        {
            this.Mappings.Add(new FixedWidthMapping<T>(expr, startIndex, length, trim));
        }

        public List<BaseMapping<T>> Mappings { get; private set; }
    }
}