using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{

    [SerializeField] float duracao = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duracao);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10, 30, 45) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera"))
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Jogo>().instanciar = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tag == "Coletavel")
        {
          
            if (collision.gameObject.tag == "Player")
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                Destroy(gameObject);
            }
        }
    }
}
