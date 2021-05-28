using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControloCamera : MonoBehaviour
{
    [SerializeField]
    GameObject jogador;

    private Vector3 diferenca;

    // Start is called before the first frame update
    void Start()
    {
        diferenca = transform.position - jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.transform.position + diferenca;
    }
}
