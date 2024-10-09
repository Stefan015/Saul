using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    public GameLogic gameLogic;

    public void Quit()
    {
        Application.Quit();
        Debug.Log("player has quit the game");
    }
    public void ResetProgress()
    {
        gameLogic.resetProgress();
    }
}
