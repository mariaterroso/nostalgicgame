using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoDestrutivel : MonoBehaviour
{

    NavMeshAgent agente;
    Transform alvo;
    [SerializeField] private AudioSource som;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        som = som.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = alvo.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Já foste");
            Interface.gameover = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            som.Play();
        }
    }
}
