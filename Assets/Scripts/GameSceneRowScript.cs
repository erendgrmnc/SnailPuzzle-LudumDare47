using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneRowScript : MonoBehaviour
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

    public List<Color> GiveColorsOfSquares()
    {
        List<Color> rowColors = new List<Color>();

        foreach (var square in squares)
        {
            SpriteRenderer ms = square.GetComponent<SpriteRenderer>();
            rowColors.Add(ms.color);
        }

        return rowColors;

    }

    public void SetSquaresWhite()
    {
        foreach(var square in squares)
        {
            SpriteRenderer ms = square.GetComponent<SpriteRenderer>();
            ms.color = Color.white;
        }
    }
}
