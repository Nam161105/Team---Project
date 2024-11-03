using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausePanel : MonoBehaviour
{
    [SerializeField] protected GameObject _pausePanel;
    [SerializeField] protected HealthSCTO _healthSc;
    public void PanelPause()
    {
        _pausePanel.SetActive(true);
    }

    public void Resume()
    {
        _pausePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _healthSc.currentHp = _healthSc.maxHp;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(CONSTANT._mainMenu);
    }
}
