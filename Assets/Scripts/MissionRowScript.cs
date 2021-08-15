using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionRowScript : MonoBehaviour
{
    public GameObject[] squares;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColorOfSquare(int squareNumber,string colorStr)
    {
        try
        {
            Image ms = squares[squareNumber].GetComponent<Image>();
            if (colorStr == "red")
            {
                ms.color = Color.red;
            }
            else if (colorStr == "blue")
            {
                ms.color = Color.blue;
            }
            else if(colorStr == "green")
            {
                ms.color = Color.green;
            }
            else
            {
                ms.color = Color.white;
            }
          
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);

        }
    }
    
    public List<Color> GiveColorsOfSquares()
    {
        List<Color> rowColors = new List<Color>();

        foreach(var square in squares)
        {
            Image ms = square.GetComponent<Image>();
            rowColors.Add(ms.color);
        }

        return rowColors;

    }
}
