using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    Rigidbody projectil;

    [SerializeField]
    float forcaDisparo = 500;

    private bool disparar = true;

    int pontos = 0;

    [SerializeField]
    Text pontosTexto;

    [SerializeField]
    GameObject vitoriatexto;

    Vector3 jogadorposicaooriginal;

    Quaternion jogadororeintacaooriginal;

    [SerializeField] GameObject porta;

    // Start is called before the first frame update
    void Start()
    {
        jogadorposicaooriginal = transform.position;
        jogadororeintacaooriginal = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Fire1") && disparar)
        {
            Rigidbody disparo = Instantiate(projectil, transform.position, transform.rotation) as Rigidbody;
            disparo.AddForce(transform.forward * forcaDisparo);
            disparar = false;
        }else if (Input.GetButtonUp("Fire1"))
        {
            disparar = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            AtualizaPontos();
        }
        if (other.CompareTag("Respawn"))
        {
            transform.position = jogadorposicaooriginal;
            transform.rotation = jogadororeintacaooriginal;

            porta.SetActive(true);
        }
        else if (other.CompareTag("Coletavel"))
        {
            Destroy(other.gameObject);
            porta.SetActive(false);
        }

        if (other.CompareTag("Som"))
        {
            other.GetComponent<AudioSource>().Play();
        }
        if (other.CompareTag("SomColetavel"))
        {
            other.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Som"))
        {
            other.GetComponent<AudioSource>().Stop();
        }
        if (other.CompareTag("SomColetavel"))
        {
            other.GetComponent<AudioSource>().Stop();
        }
    }

    void AtualizaPontos()
    {
        pontos++;
        pontosTexto.text = "Collectibles: " + pontos + "/3";
        if (GameObject.FindGameObjectsWithTag("Coletavel").Length <= 0)
        {
            vitoriatexto.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}