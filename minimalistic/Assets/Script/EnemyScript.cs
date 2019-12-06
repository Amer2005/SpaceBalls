using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float thrust = 0.02f;
    Rigidbody2D rb;

    GameObject Player;

    public GameObject explosion;

    public float maxHealth = 1;
    float Health;
    public float BulletDamage = 1;
    public CameraScript cameraShake;

    public float defaultScale = 1;
    public float minScale = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        cameraShake = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraScript>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * thrust);
        thrust = 0;

        gameObject.transform.localScale = new Vector3(minScale + (defaultScale - minScale) * (Health / maxHealth), minScale + (defaultScale - minScale) * (Health / maxHealth), 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet")
        {
            Health -= BulletDamage;
            if (Health <= 0)
            {
                EZCameraShake.CameraShaker.Instance.ShakeOnce(4f,6f,0.2f,0.2f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (col.tag == "Enemy")
        {
            EZCameraShake.CameraShaker.Instance.ShakeOnce(8f, 12f, 0.4f, 0.4f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
