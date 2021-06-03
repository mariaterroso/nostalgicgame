using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    GameObject fogo;

    int pontos = 0;

    [SerializeField]
    Text pontosTexto;

    [SerializeField]
    GameObject vitoriatexto;

    Vector3 jogadorposicaooriginal;

    Quaternion jogadororeintacaooriginal;

    [SerializeField]
    int vida = 3;

    [SerializeField] GameObject porta;

    // Start is called before the first frame update
    void Start()
    {
        jogadorposicaooriginal = transform.position;
        jogadororeintacaooriginal = transform.rotation;
    }

    // Update is called once per frame
   

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

        if (tag == "Player")
        {
            vida--;
            if (vida == 0)
            {
                if (other.gameObject.tag == "Indestrutivel")
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOver");

                }
            }
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
        pontosTexto.text = "Pontos: " + pontos;
        if (GameObject.FindGameObjectsWithTag("Coletavel").Length <= 0)
        {
            vitoriatexto.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}