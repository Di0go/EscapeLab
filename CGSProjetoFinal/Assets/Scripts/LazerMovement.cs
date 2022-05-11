using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    public Vector3 pointA, pointB; // Posicão inicial/final
    public float vel; //velocidade do lerp
    Transform mov;
    float l;
    void Start()
    {
        mov = GetComponent<Transform>();
        l = 0;

        mov.position = pointA;
    }

    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        float lc = l;
        if (lc < 1) mov.position = Vector3.Lerp(pointA, pointB, l);
        else mov.position = Vector3.Lerp(pointB, pointA, l - 1f);
        
        l += vel;
        if (lc > 2) l = 0;
    }
}
