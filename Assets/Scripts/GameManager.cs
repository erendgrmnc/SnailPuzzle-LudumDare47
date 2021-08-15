using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MissionScript ms;
    public Text timeText;
    public Text scoreText;
    public Text retryMenuScoreText;
    public Text highScoreText;

    public float timeRemaining = 0;
    public int score = 0;
    public int levelsPassed = 0;
    public bool isMissionGiven = false;
    public bool isMissionPassed = false;
    string missionType;
    int timeAddition;

    public GameSceneScript gss;
    public MissionScript mss;
    public AudioSource gameMusic;
    public GameObject missionPanel;
    public GameObject retryMenu;
    public Sprite[] backgrounds = new Sprite[3];
    public SpriteRenderer background;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        timeAddition = 10;
        timeRemaining = 60;
        GiveMission();
        // LogColors();
        IsMissionCompleted();
        gameMusic.Play();

    }

    // Update is called once per frame
    void Update()
    {

        TimeCount();
        PrintScoreText();
        GiveMission();
        IsMissionCompleted();
        IsMissionPassed();
        ChangeBackgroundImage();
    }

    void TimeCount()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            if (seconds < 10)
            {
                timeText.text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                timeText.text = minutes.ToString() + ":" + seconds.ToString();
            }

        }

        else
        {
            retryMenu.SetActive(true);
            if (score>PlayerPrefs.GetInt("HighScore",0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScoreText.text = score.ToString();
            }
            Time.timeScale = 0f;
            Debug.Log("Time Up !");
        }
    }

    void GiveMission()
    {
        if (!isMissionGiven)
        {
            if (timeRemaining > 0)
            {
                if (levelsPassed < 10)
                {
                    ms.Give3x3Mission();
                    missionType = "3x3";
                    Debug.Log("3x3 Mission Given !");
                    isMissionGiven = true;
                }
                else if (levelsPassed >= 10 && levelsPassed <= 30)
                {
                    ms.Give5x5Mission();
                    missionType = "5x5";
                    Debug.Log("5x5 Mission Given !");
                    isMissionGiven = true;
                }
                else
                {
                    ms.Give7x7Mission();
                    missionType = "7x7";
                    Debug.Log("7x7 Mission Given !");
                    isMissionGiven = true;
                }
            }
        }
    }

    void IsMissionPassed()
    {
        if (isMissionPassed)
        {
            if (levelsPassed < 9)
            {
                timeAddition = 15;
            }
            else if (levelsPassed == 9)
            {
                timeAddition = 120;
            }
            else if (levelsPassed > 10 && levelsPassed < 29)
            {
                timeAddition = 30;
            }
            else if (levelsPassed == 29)
            {
                timeAddition = 180;
            }
            else
            {
                timeAddition = 45;
            }

            timeRemaining += timeAddition;

            if (missionType == "3x3")
            {

                score += 15;
                levelsPassed++;
            }
            else if (missionType == "5x5")
            {


                score += 30;
                levelsPassed++;
            }
            else
            {

                score += 55;
                levelsPassed++;
            }
            isMissionGiven = false;
            isMissionPassed = false;
            gss.SetRowsWhite();
        }
    }

    void PrintScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        retryMenuScoreText.text = "You Scored \n" + score.ToString();
    }

    void IsMissionCompleted()
    {
        bool isAnyDifferent = false;
        List<List<Color>> gameColors = gss.ReturnSceneColors();
        List<List<Color>> missionColors = mss.ReturnMissionColors();

        for (int i = 0; i < gameColors.Count; i++)
        {
            List<Color> gRow = gameColors[i];
            List<Color> mRow = missionColors[i];

            for (int j = 0; j < gRow.Count; j++)
            {
                if (gRow[j].ToString() != mRow[j].ToString())
                {
                    isAnyDifferent = true;
                    break;
                }
            }

        }



        if (isAnyDifferent == false)
        {
            isMissionPassed = true;
            Debug.Log("Mission Passed !");
        }
    }

    void LogColors()
    {
        List<List<Color>> gameColors = gss.ReturnSceneColors();
        List<List<Color>> missionColors = mss.ReturnMissionColors();

        int gRowCounter = 0;
        foreach (var rows in gameColors)
        {
            foreach (var row in rows)
            {
                if (gRowCounter == 1)
                {
                    Debug.Log(row.ToString());
                }

            }
            gRowCounter++;
            if (gRowCounter == 2)
            {
                break;
            }
        }

        Debug.Log("----------------");

        int mRowCounter = 0;
        foreach (var rows in missionColors)
        {
            foreach (var row in rows)
            {
                if (mRowCounter == 1)
                {
                    Debug.Log(row.ToString());
                }

            }
            mRowCounter++;
            if (mRowCounter == 2)
            {
                break;
            }

        }


    }

    public void HideMissionPanel()
    {
        if (missionPanel.activeSelf)
        {
            missionPanel.SetActive(false);
        }
        else
        {
            missionPanel.SetActive(true);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SupportUs()
    {
        Application.OpenURL("https://www.patreon.com/user?u=43449633");
    }

    public void ChangeBackgroundImage()
    {
        if (levelsPassed < 10)
        {
            background.sprite = backgrounds[0];
        }

        if (levelsPassed >= 10 && levelsPassed < 30)
        {
            background.sprite = backgrounds[1];
        }
        else
        {
            background.sprite = backgrounds[2];
        }
    }


}
