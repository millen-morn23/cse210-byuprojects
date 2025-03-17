class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // Optional for multi-verse references

    // Constructor for single-verse references
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1; // -1 means there's no end verse
    }

    // Constructor for multi-verse references (e.g., John 3:16-17)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Converts a reference string into a Reference object (e.g., "John 3:16")
    public Reference(string referenceString)
    {
        string[] parts = referenceString.Split(' ');
        _book = parts[0];

        string[] chapterVerse = parts[1].Split(':');
        _chapter = int.Parse(chapterVerse[0]);

        if (chapterVerse[1].Contains("-")) // If it's a range of verses
        {
            string[] verses = chapterVerse[1].Split('-');
            _verse = int.Parse(verses[0]);
            _endVerse = int.Parse(verses[1]);
        }
        else
        {
            _verse = int.Parse(chapterVerse[1]);
            _endVerse = -1;
        }
    }

    // Return the formatted reference text
    public string GetDisplayText()
    {
        return _endVerse > 0 ? $"{_book} {_chapter}:{_verse}-{_endVerse}" : $"{_book} {_chapter}:{_verse}";
    }
}
