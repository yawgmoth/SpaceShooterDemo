using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : UnitController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 60*Time.time);
        Shoot(6, 100, 5);
    }

    public override void OnDeath()
    {
        GameState.points += 1;
        Destroy(gameObject);
    }
}
