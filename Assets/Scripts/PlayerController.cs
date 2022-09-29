using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : UnitController
{
    public float speed;
    public float boosted_speed;
    public bool boosting;
    public Transform holder;

    

    public TextMeshProUGUI death_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnDeath()
    {
        Debug.Log("player death");
        death_text.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if (Mathf.Abs(dx) > 0.001)
        {
            holder.position += transform.rotation*new Vector3(dx * Time.deltaTime * speed, 0, 0);
        }
        if (Mathf.Abs(dy) > 0.001)
        {
            holder.position += transform.rotation*new Vector3(0, dy * Time.deltaTime * speed, 0);
        }
        Vector3 mouseCur = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 toMouse = mouseCur - transform.position;
        float angle = Mathf.Atan2(toMouse.y, toMouse.x);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg*angle-90);

        if (Input.GetButton("Jump") && !boosting)
        {
            StartCoroutine(Boost());
        }

        if (Input.GetMouseButton(0))
        {
            Shoot(14, 10, 5);
        }
    }

    IEnumerator Boost()
    {
        boosting = true;
        float current_speed = speed;
        speed = boosted_speed;
        yield return new WaitForSeconds(2);
        speed = current_speed;
        yield return new WaitForSeconds(3);
        boosting = false;
    }
}
