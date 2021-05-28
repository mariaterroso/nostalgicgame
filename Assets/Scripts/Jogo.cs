using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    [SerializeField] GameObject colectavel;
    [SerializeField] Transform[] coordenadas = new Transform[5];

    private int sorteado = 0;
    public bool instanciar = true;


    // Update is called once per frame
    void Update()
    {
        if (instanciar)
        {
            instanciar = false;
            Invoke("InstanciaColectavel", Random.Range(1, 3));
        }
    }

    void InstanciaColectavel()
    {
        sorteado = sorteio(0, 4);
        Instantiate(colectavel, coordenadas[sorteado].position, Quaternion.identity);
    }

    int sorteio(int minimo, int maximo)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        return minimo + (sorteado - minimo + Random.Range(1, maximo - minimo)) % (maximo - minimo);
    }
}
