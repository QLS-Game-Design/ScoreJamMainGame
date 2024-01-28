using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 2f;

    void Start()
    {
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyScript>(out EnemyScript enemy))
        {
            enemy.TakeDamage(1);
        }
        Destroy(gameObject);
        Debug.Log()
    }
}