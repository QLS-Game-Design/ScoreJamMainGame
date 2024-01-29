using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Transform targetPlayer;
    private float distance;
    [SerializeField] float health, maxHealth = 50f;
    [SerializeField] EnemyHealthbar healthBar;
    private LevelingScript levelingScript; // Remove [SerializeField] attribute
    private bool touching;
    public float hitInterval = 2;
    float time;

    public Sprite frameOne;
    public Sprite frameTwo;

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthbar>();
        levelingScript = FindObjectOfType<LevelingScript>(); // Find LevelingScript component in the scene
    }

    void Start()
    {
        if (healthBar == null)
        {
            Debug.LogError("EnemyHealthbar component not found.");
        }
        else
        {
            healthBar.UpdateHealthBar(maxHealth, maxHealth);
            StartCoroutine(Animation());
        }
    }

    private IEnumerator Animation()
    {
        while (true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = frameOne;
            yield return new WaitForSeconds(0.25f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = frameTwo;
            // Yield execution of this coroutine and return to the main loop until next frame
            yield return new WaitForSeconds(0.25f);
        }
    }

    void Update()
    {
        if (player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // moves the enemy towards the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            // changes the direction of the enemy to point towards the player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

        time += Time.deltaTime;
        if (touching && time >= hitInterval)
        {
            time = 0.0f;
            if (player != null && player.GetComponent<PlayerMovement>() != null)
            {
                player.GetComponent<PlayerMovement>().Hit(30);
                Debug.Log("Player hit by enemy");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touching = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touching = false;
        }
    }

    public void Die()
    {
        player.GetComponent<PlayerMovement>().score++;
        if (levelingScript != null)
        {
            levelingScript.currLevel += 2;
            levelingScript.UpdateLevel();
        }
        else
        {
            Debug.LogWarning("LevelingScript component not found.");
        }
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }
        else
        {
            Debug.LogWarning("EnemyHealthbar component not found.");
        }
        if (health <= 0)
        {
            Die();
        }
    }
}
