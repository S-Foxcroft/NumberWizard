using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    int min = 1, max = 1000, guesses = 0, upper, lower, guess;
    bool started = false, over = false;
    [SerializeField] GameObject player;
    [SerializeField] GameObject next;
    [SerializeField] Text numberDisplay;
    [SerializeField] Text dialog;
    string toDialog;
    void Start()
    {
        guesses = 0;
        upper = max+1;
        lower = min;
        toDialog = "Select a number between " + min + " and " + max + " then click next.";
        player.SetActive(false);
        next.SetActive(true);
        MakeGuess(500);
    }
    void MakeGuess(int theGuess)
    {
        if (upper == lower || lower == max)
        {
            if (upper >= max) toDialog = "Your number was too high to guess!";
            else if (lower == min) toDialog = "Your number was too low to guess!";
            else toDialog = "Your number was " + guess + " and it took me " + guesses + " attempts to find it!";
            over = true;
            player.SetActive(false);
            next.SetActive(true);
        }
        guess = (theGuess > 0) ? theGuess : Random.Range(lower,upper);
        guesses += 1;
    }

    // Update is called once per frame
    void Update()
    {
        numberDisplay.text = ""+guess;
        dialog.text = toDialog;
    }
    public void OnUpClicked()
    {
        lower = guess;
        MakeGuess(-1);
    }
    public void OnDownClicked()
    {
        upper = guess;
        MakeGuess(-1);
    }
    public void OnYesClicked()
    {
        over = true;
        toDialog = "Your number was " + guess + " and it took me " + guesses + " attempts to find it!";
        player.SetActive(false);
        next.SetActive(true);

    }
    public void OnNextClicked()
    {
        if (!started)
        {
            started = true;
            player.SetActive(true);
            next.SetActive(false);
        }
        else if (over)
        {
            SceneManager.LoadScene(2);
        }
    }

}
