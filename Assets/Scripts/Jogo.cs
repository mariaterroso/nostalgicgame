using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    [SerializeField] GameObject colectable;
    [SerializeField] Transform[] coordenadas = new Transform[5];

    private int sorteado = 0;
    public bool instanciar = true;

    [SerializeField] float temporizador = 30;
    private bool contaTempo = true;
    [SerializeField] Text mostrador;

    // Update is called once per frame
    void Update()
    {
        ContadorTemporal();
        if (instanciar)
        {
            instanciar = false;
            Invoke("InstanciaColectavel", Random.Range(1, 3));
        }
    }

    void InstanciaColectavel()
    {
        sorteado = sorteio(0, 4);
        Instantiate(colectable, coordenadas[sorteado].position, Quaternion.identity);
    }

    int sorteio(int minimo, int maximo)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        return minimo + (sorteado - minimo + Random.Range(1, maximo - minimo)) % (maximo - minimo);
    }

    void ContadorTemporal()
    {
        MostraTempo(temporizador);
        if (contaTempo)
        {
            if (temporizador > 0)
            {
                temporizador -= Time.deltaTime;
            }
            else
            {
                temporizador = 0;
                contaTempo = false;
                Interface.gameover = true;
            }
        }
    }

    void MostraTempo(float relogio)
    {
        float minutos = Mathf.FloorToInt(relogio / 60);
        float segundos = Mathf.FloorToInt(relogio % 60);

        mostrador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
