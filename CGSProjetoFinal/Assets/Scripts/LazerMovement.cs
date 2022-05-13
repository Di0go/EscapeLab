using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    public Vector3 pointA, pointB; // Posicão inicial/final
    public float vel; //velocidade do lerp
    Transform mov;
    float l;

    //raycast to detect the ground or the walls
    private RaycastHit hit;

    void Start()
    {
        mov = GetComponent<Transform>();
        l = 0;

        pointA = mov.position;

        //pointB calculations

        //if the laser is horizontal (z 90 º) point b is assigned to the first point that the ray hits in the ground
        if (mov.eulerAngles.z == 90 && Physics.Raycast(pointA, Vector3.down, out hit))
        {
            pointB = hit.point;
        }
        //same but for vertical lasers
        else if (mov.eulerAngles.z == 0 && mov.position.x >= 0 && Physics.Raycast(pointA, Vector3.left, out hit))
        {
            pointB = hit.point;
        }
        else if (mov.eulerAngles.z == 0 && mov.position.x < 0 && Physics.Raycast(pointA, Vector3.right, out hit))
        {
            pointB = hit.point;
        }
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
