using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance =  Vector2.Distance(transform.position, player.transform.position);
        System.Numerics.Vector2 direction = player.transform.position - transform.position;

        transform.position-= Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
