using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;

public class PlayerMovement : MonoBehaviour
{
    public Leaderboard leaderboard;
    public int score;

    public float speed = 5f;
    
    public float maxHealth = 100;
    public float timeInvincible = 2.0f;
    public float currHealth;

    
    public bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    [SerializeField]
    float rotationSpeed;

    //sprites
    public Sprite bacteriaUp;
    public Sprite bacteriaDown;
    public Sprite bacteriaLeft;
    public Sprite bacteriaRight;
    public Sprite bacteria;
    public GameOverScript gameOverScript;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
        score = 0;
    }

    void Update()
    {
        horizontal = 0f;
        vertical = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bacteriaUp;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bacteriaDown;
        } 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bacteriaRight;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bacteriaLeft;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bacteria;

        }

        if (horizontal != 0 || vertical != 0)
        {
            speed = 5f; // Set full speed when a movement key is pressed
        }
        else
        {
            speed = 0f; // Set speed to 0 when no movement key is pressed
        }
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = (position.x + speed * horizontal * Time.deltaTime);
        position.y = (position.y + speed * vertical * Time.deltaTime);
        
        rigidbody2d.MovePosition(position);

        if (currHealth <= 0) {
            gameOverScript.gameOver();
            StartCoroutine(DieRoutine());
        }
    }

    IEnumerator DieRoutine() {
        
        yield return leaderboard.SubmitScoreRoutine(score);
        
        Destroy(gameObject);
    }

    public void Hit(int damage)
    {
        if (isInvincible) {
            return;
        }
        
        isInvincible = true;
        invincibleTimer = timeInvincible;

        currHealth -= damage;
    }
}
