using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSquareScript : MonoBehaviour
{
    
    Image spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveColor(string colorStr)
    {
        if (colorStr == "red")
        {
            spriteRenderer.color = Color.red;
        }
        else if (colorStr == "blue")
        {
            spriteRenderer.color = Color.blue;
        }
        else if(colorStr == "green")
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
        
    }

    public Color ReturnColor()
    {
        return spriteRenderer.color;
    }

}
