using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, 1f);
    }
}
