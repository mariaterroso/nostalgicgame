using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            float velocidadesalto = 5f;
            rb.velocity = Vector2.up * velocidadesalto;
        }
    }
}