using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject settingPanel;
    public void OnContinueButtonClick()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void OnSettingsButtonClick()
    {
        settingPanel.SetActive(true);
    }

    public void OnSettingsCloseButtonClick()
    {
        settingPanel.SetActive(false);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
