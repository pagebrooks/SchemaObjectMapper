using System.Linq;
using System.Collections.Generic;
using System;

namespace SchemaObjectMapper
{
    public class DelimitedSchemaObjectMapper<T> : ISchemaObjectMapper<T> where T : new()
    {
        private readonly string[] _delimiter;
        private readonly ISchema<T> _delimitedSchema;

        public DelimitedSchemaObjectMapper(ISchema<T> delimitedSchema, params string[] delimiter)
        {
            this._delimitedSchema = delimitedSchema;
            this._delimiter = delimiter;
        }

        public T MapLine(string line)
        {
            var tokens = line.Split(this._delimiter, StringSplitOptions.None);
            if (tokens.Length < this._delimitedSchema.Mappings.Count)
            {
                throw new ArgumentException("There are more mappings defined than available tokens.");
            }

            var obj = new T();
            foreach (DelimitedMapping<T> mapping in this._delimitedSchema.Mappings)
            {
                var value = Convert.ChangeType(tokens[mapping.Ordinal], mapping.PropertyInfo.PropertyType);
                mapping.PropertyInfo.SetValue(obj, value, null);
            }

            return obj;
        }
    }
}