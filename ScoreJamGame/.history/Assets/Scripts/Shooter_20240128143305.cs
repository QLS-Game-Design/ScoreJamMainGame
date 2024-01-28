using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform player;
    public float bulletSpeed = 10f;
    public float rotationSpeed = 5f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - player.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion playerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        player.rotation = Quaternion.Slerp(player.rotation, playerRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = player.rotation;
        player.rotation.normalized();
        // Vector3 offset = new Vector3(0f, 0f, 0f);
        // transform.position = player.position + offset;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = bullet.transform.right * bulletSpeed;
        }
    }
}
