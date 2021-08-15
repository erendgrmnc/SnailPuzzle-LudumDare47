using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D physics;

    float horizontalInput;
    float verticalInput;
   
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    public bool canMove = true;
    public int moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //KeepTheCameraInside();
    }

    void MovePlayer()
    {
        if (canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
            verticalInput = Input.GetAxisRaw("Vertical") * moveSpeed;
            physics.velocity = new Vector2(horizontalInput, verticalInput);
            

        }
        else
        {
            physics.velocity = Vector2.zero;
            
        }
    }

    void KeepTheCameraInside()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 0.5f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -0.5f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Square")
        {
           
          
        }

    }
}
