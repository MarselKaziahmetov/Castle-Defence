using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void OnContinueButtonClick()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void OnSettingsButtonClick()
    {

    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
