using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public Bullet bullet;


    public private void Start() {
        
    }
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            transform.position = desiredPosition;
        }
    }
}
