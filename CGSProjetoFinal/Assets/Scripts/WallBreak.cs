using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private Rigidbody rb;
    private bool t;
    private Vector3 Forca;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.mass = 3;
        rb.drag = 0;
        t = true;
        Forca = new Vector3(Random.Range(-20f, 20f), Random.Range(20f, 25f), Random.Range(1f, 20f));
       
    }

    void Update()
    {
        
        if (t)
        {
            rb.AddForce(Forca, ForceMode.Impulse);
            t = false;
        }
    }
}
