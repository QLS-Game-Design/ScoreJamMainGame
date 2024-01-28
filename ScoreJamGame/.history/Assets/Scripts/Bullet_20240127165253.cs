using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyScript>(out EnemyScript enemy))
        {
            enemy.TakeDamage(1);
            Debug.Log("hit");
        }
        Destroy(gameObject);
    }
}