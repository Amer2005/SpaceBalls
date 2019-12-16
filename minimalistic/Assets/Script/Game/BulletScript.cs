using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float thrust = 500.0f;
    Rigidbody2D rb;
    SpriteRenderer m_Renderer;

    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        m_Renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(Player.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * thrust);
        thrust = 0;
        if (!m_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
