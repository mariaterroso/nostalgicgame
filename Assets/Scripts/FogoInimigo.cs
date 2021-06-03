using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoInimigo : MonoBehaviour
{

    float velocidade = 10f;

    Rigidbody rb;

    GameObject alvo;

    Vector3 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        alvo = GameObject.FindGameObjectWithTag("Player");
        direcao = (alvo.transform.position - transform.position).normalized * velocidade;
        rb.velocity = new Vector3(direcao.x, direcao.y, direcao.z);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}