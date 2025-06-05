using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEditor.ShaderGraph.Internal;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Game currentGame;
    public TextMeshProUGUI playedWords;
    public TextMeshProUGUI playedWordsCount;
    public TextMeshProUGUI gameMessage;
    public TMP_InputField intputField;
    public TextMeshProUGUI resultWords;

    [Header("RandomWords")]
    public int numeroDuMotChoisiAuHasard;
   public  string motAtrouver;

    public string[] words = new string[] { "MAITRE", "RENARD", "CHANTER", "PLUME", "CORBEAUX", "FROMAGE" };
    System.Random random = new System.Random();

    void Start()
    {
        numeroDuMotChoisiAuHasard = random.Next(words.Length);
        motAtrouver = words[numeroDuMotChoisiAuHasard];

        currentGame = new Game(motAtrouver);
        Debug.Log(numeroDuMotChoisiAuHasard);
        Debug.Log(motAtrouver);

    }

    public void OnLetterPlayed(string letter)
    {
        Debug.Log(letter);
        int i = currentGame.playedLetterCorrects.Count;
        for (i = 0; i < currentGame.playedLetterCorrects.Count; i++)
        {
            if (currentGame.playedLetterCorrects[i] == letter)
            {
                gameMessage.text = "Vous avez deja utilisé cette lettre !!";
                StartCoroutine(temps(2));
            }
        }

        if (currentGame.word.Contains(letter))
        {
            Debug.Log("Letter is in the word!");
            currentGame.playedLetterCorrects.Add(letter);
            currentGame.playedLetters.Add(letter);
            int ii = currentGame.playedLetterCorrects.Count;
            string result = String.Empty;
            for (ii = 0; ii < currentGame.playedLetterCorrects.Count; ii++)
            {
                result += currentGame.playedLetterCorrects[ii];
                resultWords.text = result;
            }
        }

        if (!currentGame.word.Contains(letter))
        {
            currentGame.playedLetters.Add(letter);
            int iii = currentGame.playedLetters.Count;
            string result = String.Empty;
            for (iii = 0; iii < currentGame.playedLetters.Count; iii++)
            {
                result += currentGame.playedLetters[iii];
                // result += currentGame.playedLetterCorrect[iii];
                playedWords.text = result;
            }
        }
    }
    void EffaceText()
    {

        intputField.text = "";
    }

    IEnumerator temps(float t)
    {
        yield return new WaitForSeconds(t);
        gameMessage.text = "";
    }


    public void randomWords()
    {

    }



}
