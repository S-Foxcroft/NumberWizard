using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    DateTime t;
    int count, min=1, max=1000,guesses=0,upper,lower,guess;
    bool gameOver = false, started = false;
    void Start()
    {
        t = DateTime.Now;
        Debug.Log("Welcome to Number Wizard, the home of the most calculating mage.");
        count = 0;
        upper = max+1;
        lower = min;
        Debug.Log(": Select a number ("+min+"-"+max+") then press SPACE to begin.");
        
    }

    void MakeGuess(int theGuess)
    {
        guess = theGuess;
        Debug.Log(": Is your number higher or lower than " + theGuess + "?\n" +
                  "Press UP for higher, DOWN for lower, SPACE for equal.");
    }
    void Complain(bool high)
    {
        Debug.Log("! I can't reach your number, it is too" + (high ? "high!" : "low!"));
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
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
                gameOver = true;
                Debug.Log("Your number was {"+guess+"} & it took me "+guesses+" attempts to find it!");
            }
        }
        if (!started)
        {
            if (Input.GetKeyDown("space"))
            {
                started = true;
                MakeGuess(500);
            }
        }
        //Frame counting should always be the last thing to do after the game logic. CheckFrame(bool log)
        CheckFrame(false);
    }

    

    void CheckFrame(bool log)
    {
        DateTime n = DateTime.Now;
        count = count + 1;
        if (n.Second == t.Second + 1)
        {
            if(log) Debug.Log("FPS: " + count);
            count = 0;
            t = n;
        }
    }
}
