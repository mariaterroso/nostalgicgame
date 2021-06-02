using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    float min = 2f;

    float max = 3f;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 3, max - min) + min, transform.position.z, transform.position.y);
    }
}
