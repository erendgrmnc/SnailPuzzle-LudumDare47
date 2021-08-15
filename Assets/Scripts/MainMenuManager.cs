using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text highScoreText;
    public void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public GameObject settingsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void SupportUs()
    {
        Application.OpenURL("https://www.patreon.com/user?u=43449633");
    }

    public void OpenSettingsPanel()
    {
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
        }
    }

    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
