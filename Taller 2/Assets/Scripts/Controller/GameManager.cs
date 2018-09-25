using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public void PausedGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }

    public void ExitGame() {
        Application.Quit();
    }
}
