using System.Linq;
using System.Collections.Generic;
using System;

namespace SchemaObjectMapper
{
    public class FixedWidthSchemaObjectMapper<T> : ISchemaObjectMapper<T> where T : new()
    {
        private readonly ISchema _schema;

        public FixedWidthSchemaObjectMapper(ISchema schema)
        {
            this._schema = schema;
        }

        public T MapLine(string line)
        {
            var obj = new T();
            foreach (FixedWidthMapping<T> mapping in this._schema.Mappings)
            {
                var rawValue = line.Substring(mapping.Start, mapping.Length);
                var value = Convert.ChangeType(mapping.Trim ? rawValue.Trim() : rawValue, mapping.PropertyInfo.PropertyType);
                mapping.PropertyInfo.SetValue(obj, value, null);
            }

            return obj;
        }
    }
}