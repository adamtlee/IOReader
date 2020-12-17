using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IOReader
{
    class CsvFileProcessor
    {
        public string InputFilePath { get;  }
        public string OutputFilePath { get;  }

        public CsvFileProcessor(string inputFilePath, string outputFilePath)
        {
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }

        public void Process()
        {
            using (StreamReader input = File.OpenText(InputFilePath))
            using (CsvReader csvReader = new CsvReader(input, System.Globalization.CultureInfo.CurrentCulture))
            {
                IEnumerable<dynamic> records = csvReader.GetRecords<dynamic>();
                csvReader.Configuration.HasHeaderRecord = false;
                foreach (var record in records)
                {
                    Console.WriteLine(record.Id);
                }    
            }
        }
    }
}
