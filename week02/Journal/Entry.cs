using System;
using System.Text;
using System.Collections.Generic;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    // Constructor used when creating a brand new entry today
    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToShortDateString();
    }

    // Constructor used when loading an entry that already has a date (from a file)
    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    // Turns this entry into a single, real CSV line (handles commas and quotes correctly)
    public string ToCsvLine()
    {
        return $"{EscapeCsvField(_date)},{EscapeCsvField(_prompt)},{EscapeCsvField(_response)}";
    }

    // Wraps a field in quotes (and doubles any internal quotes) only when it actually
    // contains a comma, a quote, or a newline. Otherwise it is left as plain text.
    private string EscapeCsvField(string field)
    {
        bool needsQuotes = field.Contains(",") || field.Contains("\"") || field.Contains("\n");

        if (needsQuotes)
        {
            string escapedField = field.Replace("\"", "\"\"");
            return $"\"{escapedField}\"";
        }

        return field;
    }

    // Rebuilds an Entry from one real CSV line (used when loading from a file)
    public static Entry FromCsvLine(string line)
    {
        List<string> fields = ParseCsvFields(line);

        string date = fields[0];
        string prompt = fields[1];
        string response = fields[2];

        return new Entry(date, prompt, response);
    }

    // Splits a CSV line into its fields, respecting quoted fields that may contain commas
    private static List<string> ParseCsvFields(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder currentField = new StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];

            if (insideQuotes)
            {
                if (currentChar == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField.Append('"');
                    i++;
                }
                else if (currentChar == '"')
                {
                    insideQuotes = false;
                }
                else
                {
                    currentField.Append(currentChar);
                }
            }
            else
            {
                if (currentChar == '"')
                {
                    insideQuotes = true;
                }
                else if (currentChar == ',')
                {
                    fields.Add(currentField.ToString());
                    currentField.Clear();
                }
                else
                {
                    currentField.Append(currentChar);
                }
            }
        }

        fields.Add(currentField.ToString());
        return fields;
    }
}
