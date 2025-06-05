using System.Collections.Generic;

[System.Serializable]

public class Game
{
    public string word;
    public string playedLetter;
    public string playedLetterCorrect;
    public List<string> playedLetters;
    public List<string> playedLetterCorrects;

    public Game(string word)
    {
        this.word = word;
        playedLetters = new List<string>();
        playedLetterCorrects = new List<string>();
    }
}
