﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitute)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitute;
            float y = Random.Range(-1f, 1f) * magnitute;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        Debug.Log("yes");
        transform.localPosition = originalPosition;
    }
}