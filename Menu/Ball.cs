using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x,-6, transform.position.z);
        }
    }
}
