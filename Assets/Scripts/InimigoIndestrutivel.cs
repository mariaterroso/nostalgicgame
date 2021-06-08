using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InimigoIndestrutivel : MonoBehaviour
{
    [SerializeField]
    GameObject inimigo1;

    [SerializeField] private AudioSource som;
    private bool destruir = false;

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

        som = som.GetComponent<AudioSource>();
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

        if (destruir)
        {
            if (!som.isPlaying) Destroy(gameObject);
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
            Interface.gameover = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            som.Play();
            destruir = true;
        }
    }
}