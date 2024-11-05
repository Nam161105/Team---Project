using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(CONSTANT._mapDemo);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
