using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    void Start()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test")
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hello");
            if (other.TryGetComponent<EnemyScript>(out EnemyScript enemy))
            {
                enemy.TakeDamage(1);
            }
            Debug.Log("world");
            Destroy(gameObject);
        }
    }
}