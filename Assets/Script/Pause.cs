using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    public void StartPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
    }
}
