using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    
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
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
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
            Destroy(gameObject);
        }
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
