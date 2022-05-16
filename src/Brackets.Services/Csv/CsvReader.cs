﻿namespace Brackets.Services.Csv
{
    public class CsvReader
    {
        public string[] ReadLines(string path)
        {
            string[] lines = File.ReadAllLines(path);
            lines = lines.Skip(1).ToArray();
            return lines;
        }
    }
}
