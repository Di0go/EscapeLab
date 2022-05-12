using UnityEngine;
//using Linq here to be able to call SequenceEqual, it apparently allows you to compare references
using System.Linq;

public class PadManager : Sequence
{
    [SerializeField] protected GameObject parentObj;

    private Renderer padRenderer;

    private void Start()
    {
        //to only change the pressed pad's material
        padRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the pad wasn't already added to the list 
        if (!playerOrder.Contains(int.Parse(transform.name)))
        {
            //add it to the list  
            playerOrder.Add(int.Parse(transform.name));

            //changes the pads material to yellow uppon activation
            padRenderer.material.color = Color.yellow;

            Debug.Log("Pad " + transform.name + " added!");

            //sequence is correct
            if (playerOrder.Count == correctOrder.Count && playerOrder.SequenceEqual(correctOrder))
            {
                ChangePadsColor(parentObj, Color.green);
            }

            //sequence is incorrect
            else if (playerOrder.Count == correctOrder.Count && !playerOrder.SequenceEqual(correctOrder))
            {
                ChangePadsColor(parentObj, Color.red);
            }
        }
        else if (playerOrder.Contains(int.Parse(transform.name)))
        {
            Debug.Log("Pad " + transform.name + " was already pressed!");
        }
    }

    //changes the pads color when the sequence is completed
    protected void ChangePadsColor(GameObject parent, Color col)
    {
        //loops trough every child object that the parent has
        foreach (Transform child in parent.transform)
        {
            //changes it's color
            child.GetComponent<Renderer>().material.color = col;
        }
    }
}
