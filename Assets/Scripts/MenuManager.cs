using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void START() {
        SceneManager.LoadScene(0);
    }
    public void EXIT() {
        Application.Quit();
    }
}
