using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        jogadorposicaooriginal = transform.position;
        jogadororeintacaooriginal = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fogo, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);
            AtualizaPontos();
        }
        if(other.CompareTag("Respawn"))
        {
            transform.position = jogadorposicaooriginal;
            transform.rotation = jogadororeintacaooriginal;
        }
    }

    void AtualizaPontos()
    {
        pontos++;
        pontosTexto.text = "Pontos" + pontos;
        if (GameObject.FindGameObjectsWithTag("Coletavel").Length <= 0)
        {
            vitoriatexto.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
