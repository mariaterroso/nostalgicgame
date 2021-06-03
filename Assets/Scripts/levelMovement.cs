using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMovement : MonoBehaviour
{
    float min = 2f;

    float max = 3f;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.y;
        max = transform.position.y + 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 3, max - min) + min, transform.position.z, transform.position.x);
    }
}
