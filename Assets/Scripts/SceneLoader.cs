using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadIntro() { SceneManager.LoadScene(0); }
    public void LoadGame() { SceneManager.LoadScene(1); }
    public void LoadEnding() { SceneManager.LoadScene(2); }
    public void LoadAbout() { SceneManager.LoadScene(3); }
    public void Exit() { Application.Quit(); }
}
