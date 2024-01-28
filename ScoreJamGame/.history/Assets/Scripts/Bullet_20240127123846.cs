using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemy)) {
            enemy.Component.TakeDamage(1);
        }
        Destroy(gameObject);
    }

}