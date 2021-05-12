using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoAmigo : MonoBehaviour
{
    [SerializeField]
    float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
