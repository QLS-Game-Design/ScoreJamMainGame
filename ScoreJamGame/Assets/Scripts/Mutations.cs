using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutations : MonoBehaviour
{
    public Bullet bullet;
    public PlayerMovement playerMovement;
    public MutationDecider mutationDecider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageBuff() {
        int index = mutationDecider.getLevelIndex("Damage");
        mutationDecider.levels[index]++;
        bullet.damage = 10*mutationDecider.levels[index];
        
    }
}
