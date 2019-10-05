﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Lifetime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAfterSeconds", Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void DestroyAfterSeconds()
    {
        Destroy(gameObject);
    }
}
