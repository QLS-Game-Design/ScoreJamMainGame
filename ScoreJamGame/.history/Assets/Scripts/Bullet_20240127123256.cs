using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    rivate void OnCollisionEnter2D(Collision2D collision) {
        
    }

}
