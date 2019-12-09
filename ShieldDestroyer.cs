using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Shield")
        {
            return;
        }

        if(other.tag == "Bolt")
        {
            Destroy(gameObject);
        }
    }
}