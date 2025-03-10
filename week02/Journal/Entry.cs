using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
    
    public override string ToString()
    {
        return $"{Date} - {Prompt}: {Response}";
    }
    
    // Converts entry to CSV format
    public string ToCSV()
    {
        return $"{Date}|{Prompt}|{Response}";
    }
    
    // Parses an entry from CSV format
    public static Entry FromCSV(string csvLine)
    {
        var parts = csvLine.Split('|');
        return new Entry(parts[0], parts[1], parts[2]);
    }
}
