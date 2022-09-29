using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public float health;
    public float max_health;

    public float fire_rate;
    public float last_shot;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnDeath()
    {

    }

    public void Shoot(float s, float d, float l)
    {
        if (Time.time > last_shot + fire_rate)
        {
            GameObject new_bullet = Instantiate(bullet,
                                  transform.position + transform.rotation * new Vector3(0, 0.65f, 0),
                                  transform.rotation);
            BulletController bullet_controller = new_bullet.GetComponent<BulletController>();
            bullet_controller.speed = s;
            bullet_controller.lifetime = l;
            bullet_controller.damage = d;
            last_shot = Time.time;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
        }
    }
}
