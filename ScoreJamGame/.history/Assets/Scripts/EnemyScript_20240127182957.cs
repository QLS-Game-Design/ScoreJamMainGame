
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    [SerializeField] float health, maxHealth = 10f;
    [SerializeField] EnemyHealthbar healthBar;
    [SerializeField] LevelingScript levelingScript;
    [SerializeField] float level, maxLevel = 7f;

    public void Awake() {
        healthBar = GetComponentInChildren<EnemyHealthbar>();
        levelingScript = GetComponentInChildren<LevelingScript>();
    }
    // Update is called once per frame

    void Start() {
        healthBar.UpdateHealthBar(maxHealth, maxHealth);
        levelingScript.updateLevel(0, maxLevel);
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

        
    }

    public void Die(){
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
