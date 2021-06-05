﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InimigoIndestrutivel : MonoBehaviour
{
    [SerializeField]
    GameObject inimigo1;

    public float tempodEespera = 1f;

    float Tempoquepassou = 3f;

    [SerializeField]
    int vidainimigo = 3;

    [SerializeField]
    float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * force);
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Destrutivel")
        {
            Tempoquepassou += Time.deltaTime;
            if (Tempoquepassou >= tempodEespera)
            {
                Instantiate(inimigo1, transform.position, transform.rotation);
                Tempoquepassou = 0f;
            }
        }
    }

        private void OnTriggerEnter(Collider other)
    {
        vidainimigo--;
        if (vidainimigo == 0)
        {
            if (other.gameObject.tag == "DisparoAmigo")
            {
                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}