using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    Rigidbody2D physics;
    SpriteRenderer spriteRenderer;
    public int colorCounter;
    private bool isPlayerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOn == true)
        {
            ChangeColor();
        }
    }


    void ChangeColor()
    {
        if (Input.GetKeyDown("space"))
        {
            if (colorCounter == 0)
            {
                spriteRenderer.color = Color.red;
                 colorCounter++;
            }
            else if (colorCounter == 1)
            {
                spriteRenderer.color = Color.green;
                 colorCounter++;
            }
            else if (colorCounter == 2)
            {
                spriteRenderer.color = Color.blue;
                colorCounter++;
            }
            else
            {
                spriteRenderer.color = Color.white;
                colorCounter = 0;
            }
            
        }
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerOn = false;
        }
    }

    public Color ReturnColor()
    {
        return spriteRenderer.color;
    }

}
