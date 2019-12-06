using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
