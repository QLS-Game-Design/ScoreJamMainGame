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
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<PlayerMovement>().Hit(20);
            Debug.Log("Hit Player");
        }
        else if (other.gameObject.CompareTag("Enemy")) 
        {
            other.gameObject.GetComponent<EnemyController>().Hit(15);
            Debug.Log("Hit Enemy");
        }

        Destroy(gameObject);
    }

}
