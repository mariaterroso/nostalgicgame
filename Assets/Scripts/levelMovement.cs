using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMovement : MonoBehaviour
{
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-20f, 0f, 0f), speed * Time.deltaTime);
     
    }
}
