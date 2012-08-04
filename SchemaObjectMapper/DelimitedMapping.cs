using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SchemaObjectMapper
{
    public class DelimitedMapping<TSource> : BaseMapping<TSource>
    {
        public DelimitedMapping(Expression<Func<TSource, object>> expr, int ordinal)
        {
            this.PropertyInfo = ReflectionHelper.GetProperty(expr) as PropertyInfo;
            this.Ordinal = ordinal;
        }

        public int Ordinal { get; set; }
    }
}