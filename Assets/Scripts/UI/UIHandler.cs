using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    bool escMenuOpen = false;

    public GameObject escMenu;
    public GameObject hudMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escMenuOpen)
            {
                escMenu.SetActive(true);
                hudMenu.SetActive(false);
                escMenuOpen = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                escMenu.SetActive(false);
                hudMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                escMenuOpen = false;
            }
        }
     
    }
}
