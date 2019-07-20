using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    DateTime t;
    int count, min=1, max=1000,guesses=0,upper,lower,guess=500;
    bool found = false;
    void Start()
    {
        Debug.Log("Start() called");
        t = DateTime.Now;
        count = 0;
        upper = max;
        lower = min;
        print(": Select a number ("+min+"-"+max+")");
        MakeGuess(500);
    }

    // Update is called once per frame
    
    void Update()
    {
        if (!found)
        {
            if (Input.GetKeyDown("up"))
            {
                lower = guess;
                guesses += 1;
                MakeGuess(lower + (upper - lower) / 2);
            }
            else if (Input.GetKeyDown("down"))
            {
                upper = guess;
                guesses += 1;
                MakeGuess(lower + (upper - lower) / 2);
            }
            else if (Input.GetKeyDown("space"))
            {
                found = true;
                print("Your number was {"+guess+"} & it took me "+guesses+" attempts to find it!");
            }
        }

        //Frame counting should always be the last thing to do after the game logic.
        CheckFrame(false);
    }

    void MakeGuess(int theGuess)
    {
        guess = theGuess;
        print(": Is your number higher or lower than " + theGuess + "?");
        print("Press UP for higher, DOWN for lower, SPACE for equal.");
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
