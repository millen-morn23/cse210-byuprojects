using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    // ✅ Fix: Add this method to allow access to the Reference object
    public Reference GetReference()
    {
        return _reference;
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} - {GetWordsText()}";
    }

    private string GetWordsText()
    {
        List<string> displayedWords = new List<string>();
        foreach (Word word in _words)
        {
            displayedWords.Add(word.IsHidden() ? "____" : word.GetText());
        }
        return string.Join(" ", displayedWords);
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
}
