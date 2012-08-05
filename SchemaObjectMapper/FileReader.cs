using System;
using System.Collections.Generic;
using System.IO;

namespace SchemaObjectMapper
{
    public class FileReader
    {
        public void ReadFile(string fileName, Action<string> lineAction)
        {
            using (var sr = new StreamReader(fileName))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    lineAction(line);
                }

                sr.Close();
            }
        }
    }
}