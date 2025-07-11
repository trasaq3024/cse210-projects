using System;
using System.Collections.Generic;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }

    public string ToCsvLine()
    {
        return $"{Escape(_date)},{Escape(_prompt)},{Escape(_response)}";
    }

    public static Entry FromCsvLine(string line)
    {
        string[] parts = ParseCsvLine(line);
        return new Entry(parts[0], parts[1], parts[2]);
    }

    private static string Escape(string input)
    {
        if (input.Contains(",") || input.Contains("\""))
        {
            input = input.Replace("\"", "\"\"");
            return $"\"{input}\"";
        }
        return input;
    }

    private static string[] ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string current = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current += '"';
                    i++;
                }
                else if (c == '"')
                {
                    inQuotes = false;
                }
                else
                {
                    current += c;
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    result.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
        }

        result.Add(current);
        return result.ToArray();
    }
}

