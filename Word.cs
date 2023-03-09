class Word
{
    private string _word;

    private bool _hidden;
    public Word(string text)
    {
        this.SetWord(text);
        this.SetHidden(false);
    }
    // this is a bit of a bad practice for future usability 
    // because you're moving business logic from another class into this one
    public void DisplayWord()
    {
        Console.Write(this.GetWord());
    }
    // typically for bool getter/setters, we change the "Get" verb to make more sense. In this case,
    // the normal convention is "IsHidden"
    public bool GetHidden()
    {
        return _hidden;
    }
    public void SetHidden(bool isHidden)
    {
        _hidden = isHidden;
    }
    public string GetWord()
    {
        if(_hidden){
            return new string('-', _word.Length);
        }
        return _word;
    
    }
    public void SetWord(string text)
    {
        _word = text;
    }
    public void HideWord()
    {
        this.SetHidden(true);
        // What's the purpose of turning it into _ if it's set to Hidden? If we wanted to ever make the word unhidden, the data would be gone.
        // Another option is to set it to hidden, and when anyone tries to DisplayWord, we just output the "_" instead. We probably don't want
        // to clobber the data.
        // this.SetWord("_");
    }

}