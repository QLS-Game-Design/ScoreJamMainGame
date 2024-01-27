using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 3f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}
