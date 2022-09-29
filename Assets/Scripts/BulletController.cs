using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Expiration());
    }

    IEnumerator Expiration()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation*new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        UnitController uc = other.GetComponent<UnitController>();
        if (uc != null)
        {
            uc.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
