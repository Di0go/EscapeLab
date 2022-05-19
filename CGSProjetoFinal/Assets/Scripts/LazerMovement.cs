using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    //automode detects ground and walls, when this is disabled manual input in the inspector is required
    public bool AutoMode = true;
    [Space]
    public Vector3 pointA, pointB; // Posicão inicial/final
    [Space]
    public float vel; //velocidade do lerp

    Transform mov;
    float l;

    //raycast to detect the ground or the walls
    private RaycastHit hit;

    //lazer damage
    [SerializeField] private int lazerDamage;

    //this var allows or denies lazer damage to the player if a certain time has or hasn't passed
    private bool canDamage;
    //this var controls the damage cooldown from the lazer
    private float lazerCooldown;

    void Start()
    {
        mov = GetComponent<Transform>();
        l = 0;

        //damage related vars
        lazerDamage = 1;
        canDamage = true;
        lazerCooldown = .75f;

        if (AutoMode)
        {
            //auto assigns Point A to the startup position
            pointA = mov.position;

            //auto assigns Point B to the raycast hit point
            //horizontal lazers
            if (mov.eulerAngles.z == 90 && Physics.Raycast(pointA, Vector3.down, out hit))
            {
                pointB = hit.point;
            }
            //vertical lazers
            else if (mov.eulerAngles.z == 0 && mov.position.x >= 0 && Physics.Raycast(pointA, Vector3.left, out hit))
            {
                pointB = hit.point;
            }
            else if (mov.eulerAngles.z == 0 && mov.position.x < 0 && Physics.Raycast(pointA, Vector3.right, out hit))
            {
                pointB = hit.point;
            }
        }
    }

    private void FixedUpdate()
    {
        float lc = l;
        if (lc < 1) mov.position = Vector3.Lerp(pointA, pointB, l);
        else mov.position = Vector3.Lerp(pointB, pointA, l - 1f);
        
        l += vel;
        if (lc > 2) l = 0;
    }

    //this method handles the lazer damage 
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && canDamage == true)
        {
            collision.gameObject.GetComponent<HealthSystem>().DamagePlayer(lazerDamage);
            canDamage = false;

            //invoke allows us to wait x time before executing a method
            Invoke("CooldownSwitch", lazerCooldown);
        }
    }

    //lazer cooldown switcher
    private void CooldownSwitch()
    {
        canDamage = true;
    }
}
