using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRigidbody;

    [SerializeField] int moveVerticalSpeed = 7;
    [SerializeField] int moveHorizontalSpeed = 5;
    [SerializeField] int playerHealth = 100;

    [SerializeField] GameObject playerDeathEffect;

    [SerializeField] AudioSource eatSoundEffect;
    [SerializeField] AudioSource dieEffect;

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
        //var horizontalInput = Input.GetAxisRaw("Horizontal");
        //myRigidbody.velocity = new Vector2(horizontalInput * moveHorizontalSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = new Vector2(moveVerticalSpeed, 0f);
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.velocity = new Vector2(0f, moveHorizontalSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myRigidbody.velocity = new Vector2(0f, -moveHorizontalSpeed);
        }
    }

    public void PlayerDeath()
    {
        Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        dieEffect.Play();

        StartCoroutine(LetTheDeathEffectPlay());
        


    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    public void PlaySoundEffect()
    {
        eatSoundEffect.Play();
    }

    IEnumerator LetTheDeathEffectPlay()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale= 0;

    }
}
