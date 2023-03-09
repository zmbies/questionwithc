class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference; 
    
    // This could probably be static to save memory
    private List<string> _scriptureList = new List<string>()
    {
        "Nephi$1$3$And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.",
        "2Nephi$31$20$Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, with a love for God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life.",
        "Doctrine and Covernants$1$28$And inasmuch as they were humble they might be made strong, and blessed from on high, and receive knowledge from time to time.",
        "Enos$1$12$And it came to pass that after I had prayed and labored with all diligence, the Lord said unto me: I will grant unto thee according to thy desires, because of thy faith.",
        "2Nephi$26$29$And now behold, I say unto you that the right way is to believe in Christ, deny him not; and Christ is the Holy One of Israel; wherefore ye must bow down before him, and worship him with all your might, mind, and strength, and your whole soul; and if ye do this ye shall in nowise be cast out."
    };

    // This works well. You could also create a static method that returns the same thing, so 
    // that this frees up the default constructor for other usage (you might want to test 
    // specific scriptures instead of getting a random one)
    public Scripture()
    {
        Random random = new Random();
        // This "-1" subtraction with random.Next could produce "0-1 = -1" which wouldn't be a valid index. The -1 is not needed
        // as .Next will not include maxValue (from the docs)
        string selectedScripture = _scriptureList[random.Next(_scriptureList.Count())];
        string[] splitScripture = selectedScripture.Split("$");
        _reference = new Reference(splitScripture[0], int.Parse(splitScripture[1]), int.Parse(splitScripture[2]));
        // foreach (string word in splitScripture[3].Split(" "))
        // {
        //     Word newWord = new Word(word); 
        //     _words.Add(newWord);
        // }
        // alternatively you can use Linq in C# to do the same thing:
        _words.AddRange(splitScripture[3].Split(" ").Select(_ => new Word(_)));
    }
    // public void DisplayReference()
    // {
    //     foreach (var word in _words)
    //     {
    //         word.DisplayWord();
    //     }
    //     Console.ReadLine();
    // }
    public void DisplayScripture()
    {
        Console.WriteLine(_reference.GetReferenceString());

        // Because we split the string into individual words, we will be missing the spaces here. 
       foreach (var word in _words)
       {
            Console.Write(word.GetWord() + " ");
       }

        // also with Linq
        // _words.ForEach(_ => Console.Write(_.GetWord() + " "));

        Console.WriteLine();
    }
    public void HideWords()
    {
        // Works great, but as you get further along, we're going to collide with already-hidden words.

        // Let's get a dictionary of unhidden words with their original index as the key
        Dictionary<int, Word> unhiddenWords = _words
                .Select((value, index) => new {value, index })
                .Where(_ => _.value.GetHidden() == false)
                .ToDictionary(pair => pair.index, pair => pair.value);

        if (unhiddenWords.Count() == 0)
        {
            // All words are hidden! Return early
            return;
        }

        Random random = new Random();
        int number = 0;
        for (int i = 0; i < 3; i++)
        {
            // Ignore this block now... this is just me thinking out loud and trying things :) 
            // }
            // while (_words[number].GetHidden())
            // {
            //     // If already hidden, then let's get another
            //     number = random.Next(0, _words.Count());

            //     // However, once all the words are hidden, this is going to be an infinite loop.
            //     // We could check if all words are hidden for each iteration, but that would be expensive.
            //     // We could create a different data structure to track if a word is hidden inside the Scripture
            //     // instead of tracking it on individual Words. That way, we can quickly find out which words are left to hide.
            //     // Also, we could just write a filter on the _words List to only grab unhidden words. This is a bit simpler
            //     // and it keeps the ownership of hidden/not hidden on the Word where it belongs.
            
            // Technically we could have a collision of the random count where we'll hide the same word twice, but oh well.
            number = random.Next(unhiddenWords.Count()); 
            int indexOfWordToHide = unhiddenWords.ElementAt(number).Key;
            _words[indexOfWordToHide].HideWord();

        }
    }


}