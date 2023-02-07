using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRigidbody;

    [SerializeField] int moveVerticalSpeed = 7;
    [SerializeField] int moveHorizontalSpeed = 5;
    [SerializeField] int playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        myRigidbody.velocity = new Vector2(moveVerticalSpeed, myRigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidbody.velocity = new Vector2(0f, moveHorizontalSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myRigidbody.velocity = new Vector2(0f, -moveHorizontalSpeed);
        }
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }
}
