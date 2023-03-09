class Reference
{
    // _book could be a Enumeration of the different books as there are finite books
    private string _book;
    // Good choice for int b/c you won't have super large numbers and don't need to deal with decimal places
    private int _chapter, _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    // You probably haven't done API annotations yet, but for something like this, 
    // it'd be good to tell class consumers the format this writes out.
    // Probably also not great practice to put parent business logic in an lower class 
    // like this.
    public void DisplayReference()
    {
        Console.WriteLine($"{_book} {_chapter}:{_verse}");
    }
    /// <summary>
    /// This method outputs the scripture's reference in standard LDS fashion.
    /// <example>
    /// For example:
    /// <code>
    /// reference.GetReferenceString();
    /// => "John 3:18"
    /// </code>
    /// </example>
    /// </summary>
    public string GetReferenceString()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
    public string GetBook()
    {
        return _book;
    }
    public void SetBook(string bookName)
    {
        _book = bookName;
    }
    public int GetChapter()
    {
        return _chapter;
    }
    public void SetChapter(int chapterNumber)
    {
        _chapter = chapterNumber;
    }
    public int GetVerse()
    {
        return _verse;
    }
    public void SetVerse(int verseNumber)
    {
        _verse = verseNumber;
    }
    
}  