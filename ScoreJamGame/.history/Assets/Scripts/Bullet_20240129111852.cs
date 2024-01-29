using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    public int damage = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Destroy(gameObject, destroyDelay);
        damage = 10;
    }

    public void upgradeDamage() {
        damage += 25;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("1");
        if (other.CompareTag("Enemy"))
        {
            // Debug.Log("2");
            if (other.TryGetComponent<EnemyScript>(out EnemyScript enemy))
            {
                enemy.TakeDamage(damage);
            }
            // Debug.Log("3");
            Destroy(gameObject);
        }
    }
}