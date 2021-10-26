using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeszkoda : MonoBehaviour
{
    private float speed = 1f;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
    }
}
