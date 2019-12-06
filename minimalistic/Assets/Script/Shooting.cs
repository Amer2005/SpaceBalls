using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    AudioSource ShootingSound;
    // Start is called before the first frame update
    void Start()
    {
        ShootingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootingSound.Play();
            var BulletObject = Instantiate(Bullet, new Vector3(0,0,0), Quaternion.identity);
            BulletObject.transform.parent = gameObject.transform;
            BulletObject.transform.position = BulletObject.transform.parent.position;
        }
    }
}
