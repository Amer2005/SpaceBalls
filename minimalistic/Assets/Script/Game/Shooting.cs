using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    AudioSource ShootingSound;
    private float timer = 0;
    private float lastShot = 0;
    public float timeBetweenShooting;
    private bool isLeftMouseButtonDown = false;
    public Text textTimer;

    // Start is called before the first frame update
    void Start()
    {
        ShootingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        isLeftMouseButtonDown = Input.GetMouseButton(0);

        if (isLeftMouseButtonDown && timer - lastShot >= timeBetweenShooting)
        {
            lastShot = timer;
            ShootingSound.Play();
            var bulletObject = Instantiate(Bullet);
            bulletObject.transform.parent = gameObject.transform;
            bulletObject.transform.position = bulletObject.transform.parent.position;
        }
        else
        {
            textTimer.text = (Math.Max(timeBetweenShooting - (timer - lastShot), 0))
                .ToString("0.##");
        }
    }
}
