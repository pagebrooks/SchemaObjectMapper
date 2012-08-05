using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SchemaObjectMapper
{
    public class FixedWidthMapping<TSource> : BaseMapping
    {
        public FixedWidthMapping(Expression<Func<TSource, object>> expr, int start, int length, bool trim)
        {
            this.PropertyInfo = ReflectionHelper.GetProperty(expr) as PropertyInfo;
            this.Start = start;
            this.Length = length;
            this.Trim = trim;
        }

        public int Start { get; set; }
        public int Length { get; set; }
        public bool Trim { get; set; }
    }
}