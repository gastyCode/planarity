using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that manages buttons in menu.
/// </summary>
public class MenuManager : MonoBehaviour
{
    public GameObject mainSection;
    public GameObject startSection;

    public void START()
    {
        mainSection.SetActive(false);
        startSection.SetActive(true);
    }

    public void START_LEVEL()
    {
        SceneManager.LoadScene(1);
    }

    public void BACK()
    {
        mainSection.SetActive(true);
        startSection.SetActive(false);
    }
    
    public void EXIT()
    {
        Application.Quit();
    }
}
