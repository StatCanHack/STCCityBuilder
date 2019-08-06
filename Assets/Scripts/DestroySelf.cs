using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    int lifetime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
