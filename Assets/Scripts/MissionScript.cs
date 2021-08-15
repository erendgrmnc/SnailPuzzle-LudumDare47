using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MissionScript : MonoBehaviour
{

    public GameObject[] rows;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Give3x3Mission()
    {
        int iterator = 0;
        string[] colors = { "red", "blue", "green","white" };
        foreach (var row in rows)
        {
            if (iterator>=2 && iterator <=4)
            {
                bool[] tilesToPaint = new bool[3];

                for (int i = 0; i < tilesToPaint.Length; i++)
                {
                    int number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        tilesToPaint[i] = false;
                    }
                    else
                    {
                        tilesToPaint[i] = true;
                    }
                }
                for (int i = 0; i < tilesToPaint.Length; i++)
                {
                    string color = colors[Random.Range(0, 4)];
                    MissionRowScript rowscrt = row.GetComponent<MissionRowScript>();
                    if (tilesToPaint[i] == true)
                    {
                        if (i == 0)
                        {
                            rowscrt.changeColorOfSquare(2, color);
                        }
                        else if(i == 1)
                        {
                            rowscrt.changeColorOfSquare(3, color);
                        }
                        else
                        {
                            rowscrt.changeColorOfSquare(4, color);
                        }
                        
                    }
                    

                }
            }
            iterator++; 
        }
    }

    public void Give5x5Mission()
    {
        int iterator = 0;
        string[] colors = { "red", "blue", "green","white" };
        foreach (var row in rows)
        {
            if (iterator >= 1 && iterator <= 5)
            {
                bool[] tilesToPaint = new bool[5];

                for (int i = 0; i < tilesToPaint.Length; i++)
                {
                    int number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        tilesToPaint[i] = false;
                    }
                    else
                    {
                        tilesToPaint[i] = true;
                    }
                }
                for (int i = 0; i < tilesToPaint.Length; i++)
                {
                    string color = colors[Random.Range(0, 4)];
                    MissionRowScript rowscrt = row.GetComponent<MissionRowScript>();
                    if (tilesToPaint[i] == true)
                    {
                        if (i == 0)
                        {
                            rowscrt.changeColorOfSquare(1, color);
                        }
                        else if (i == 1)
                        {
                            rowscrt.changeColorOfSquare(2, color);
                        }
                        else if (i == 2)
                        {
                            rowscrt.changeColorOfSquare(3, color);
                        }
                        else if (i == 3)
                        {
                            rowscrt.changeColorOfSquare(4, color);
                        }
                        else
                        {
                            rowscrt.changeColorOfSquare(5, color);
                        }

                    }
                }
            }
            iterator++;
        }
    }

    public void Give7x7Mission()
    {
        int iterator = 0;
        string[] colors = { "red", "blue", "green","white" };
        foreach (var row in rows)
        {
            if (iterator >= 0 && iterator <= 6)
            {
                bool[] tilesToPaint = new bool[7];

                for (int i = 0; i < tilesToPaint.Length; i++)
                {
                    int number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        tilesToPaint[i] = false;
                    }
                    else
                    {
                        tilesToPaint[i] = true;
                    }
                }
                for (int i = 0; i < tilesToPaint.Length; i++)
                {
                    string color = colors[Random.Range(0, 4)];
                    MissionRowScript rowscrt = row.GetComponent<MissionRowScript>();
                    if (tilesToPaint[i] == true)
                    {
                        if (i == 0)
                        {
                            rowscrt.changeColorOfSquare(0, color);
                        }
                        else if (i == 1)
                        {
                            rowscrt.changeColorOfSquare(1, color);
                        }
                        else if (i == 2)
                        {
                            rowscrt.changeColorOfSquare(2, color);
                        }
                        else if (i == 3)
                        {
                            rowscrt.changeColorOfSquare(3, color);
                        }
                        else if (i == 4)
                        {
                            rowscrt.changeColorOfSquare(4, color);
                        }
                        else if (i == 5)
                        {
                            rowscrt.changeColorOfSquare(5, color);

                        }
                        else
                        {
                            rowscrt.changeColorOfSquare(6, color);
                        }

                    }
                }
            }
            iterator++;
        }
    }

    public List<List<Color>> ReturnMissionColors()
    {
        List<List<Color>> colors = new List<List<Color>>();

        foreach(var row in rows)
        {
            MissionRowScript rowscrt = row.GetComponent<MissionRowScript>();
            colors.Add(rowscrt.GiveColorsOfSquares());
        }

        return colors;
    }

  
}
