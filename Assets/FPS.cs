using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    [SerializeField] Text fpsDisplay;
    int count = 0;
    DateTime t;
    Color32 r = new Color32(255, 0, 0, 255), g = new Color32(0, 255, 0, 255), o = new Color32(255, 140, 0, 255);
    // Start is called before the first frame update
    void Start()
    {
        t = DateTime.Now;
    }
    
    // Update is called once per frame
    void Update()
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
