using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(15);
            Debug.Log("Hit Enemy");
        }

        Destroy(gameObject);
    }

}
