
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    [SerializeField] float health, maxHealth = 50f;
    [SerializeField] EnemyHealthbar healthBar;
    [SerializeField] LevelingScript levelingScript;
    private bool touching;
    public float hitInterval = 2;
    float time;

    public void Awake() {
        healthBar = GetComponentInChildren<EnemyHealthbar>();
    }
    // Update is called once per frame

    void Start() {
        healthBar.UpdateHealthBar(maxHealth, maxHealth);
        StartCoroutine(Animation());
    }

    private IEnumerator Animation() {
        
    }
    void Update()
    {
        distance =  Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // moves the enemy towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        // changes the direction of the enemy to point towrds the player
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        time += Time.deltaTime;
        if (touching && time >= hitInterval) {
            time = 0.0f;
            player.GetComponent<PlayerMovement>().Hit(30);
            Debug.Log("Player hit by enemy");
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            touching = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            touching = false;
        }
    }

    public void Die(){
        levelingScript.currLevel += 2;
        levelingScript.updateLevel();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage) {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0) {
            Die();
        }
    }
}
