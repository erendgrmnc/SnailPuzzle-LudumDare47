using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
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

    public List<List<Color>> ReturnSceneColors()
    {
        List<List<Color>> colors = new List<List<Color>>();

        foreach (var row in rows)
        {
            GameSceneRowScript gss = row.GetComponent<GameSceneRowScript>();
            colors.Add(gss.GiveColorsOfSquares());
        }

        return colors;
    }

    public void SetRowsWhite()
    {
        foreach(var row in rows)
        {
            GameSceneRowScript gss = row.GetComponent<GameSceneRowScript>();
            gss.SetSquaresWhite();
        }
    }
}
