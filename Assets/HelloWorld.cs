using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    DateTime t;
    int min = 1, max = 1000, guesses, upper, lower, guess;
    bool gameOver = false, started = false;
    string[] lines;
    Color32 r = new Color32(255, 0, 0,255), g = new Color32(0, 255, 0,255), o = new Color32(255, 140, 0,255);
    [SerializeField] Text textWindow;
    [SerializeField] Text fpsDisplay;
    void Start()
    {
        t = DateTime.Now;
        guesses = 0;
        upper = max+1;
        lower = min;
        lines = new string[3];
        SetUILine(1, "Welcome to Number Wizard, the home of the most calculating mage.");
        SetUILine(2, ": Select a number ("+min+"-"+max+") then press SPACE to begin.");
    }

    void MakeGuess(int theGuess)
    {
        guess = theGuess;
        SetUILine(2,": Is your number higher or lower than " + theGuess + "?\n" +
                  "Press UP for higher, DOWN for lower, SPACE for equal.");
    }
    void Complain(bool high)
    {
        SetUILine(2,"! I can't reach your number, it is too " + (high ? "high!" : "low!"));
        EndGame();
    }
    void EndGame()
    {
        gameOver = true;
        SetUILine(3,"This game is now over, would you like to play again?\n"+
                  "Press SPACE to start again.");
    }
    void SetUILine(int line, string input)
    {
        lines[line - 1] = input;
    }
    // Update is called once per frame
    void Update()
    {
        //input
        if (!gameOver && started)
        {
            if (Input.GetKeyDown("up"))
            {
                lower = guess;
                guesses += 1;
                if (guess < max) MakeGuess((upper + lower) / 2);
                else Complain(true);
            }
            else if (Input.GetKeyDown("down"))
            {
                upper = guess;
                guesses += 1;
                if (guess > min) MakeGuess((upper + lower) / 2);
                else Complain(false);
            }
            else if (Input.GetKeyDown("space"))
            {
                SetUILine(2,"Your number was {"+guess+"} & it took me "+guesses+" attempts to find it!");
                EndGame();
            }
        }
        else if (!started)
        {
            if (Input.GetKeyDown("space"))
            {
                started = true;
                MakeGuess(500);
            }
        }
        else if (gameOver)
        {
            if (Input.GetKeyDown("space"))
            {
                started = false;
                gameOver = false;
                Start();
            }
        }
        //ui
        textWindow.text = lines[0] + "\n" + lines[1] + "\n" + lines[2];
        CheckFrame();
    }

    int count = 0;
    void CheckFrame()
    {
        DateTime n = DateTime.Now;
        count = count + 1;
        if (n.Second == t.Second + 1)
        {
            fpsDisplay.text = "FPS: " + count;
            if (count >= 60) fpsDisplay.color = g;
            else if (count >= 30) fpsDisplay.color = o;
            else fpsDisplay.color = r;
            count = 0;
            t = n;
        }
    }
}
