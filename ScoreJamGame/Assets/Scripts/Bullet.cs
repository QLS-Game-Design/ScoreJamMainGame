using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 6f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}
