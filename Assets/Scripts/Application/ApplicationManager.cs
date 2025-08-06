using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager Instance {  get; private set; }
    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogWarning($"有兩個ApplicationManager在場景上，將自動銷毀 : {name}");
            Destroy(this);
        }
    }
}
