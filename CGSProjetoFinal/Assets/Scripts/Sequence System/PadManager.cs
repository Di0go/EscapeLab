using UnityEngine;
//using Linq here to be able to call SequenceEqual, it apparently allows you to compare references
using System.Linq;

public class PadManager : Sequence
{
    [SerializeField] protected GameObject parentObj;

    private Renderer padRenderer;
    protected Color32 yellow, red, green, defaultColor;
    public Door door, door1;

    private void Start()
    {
        //to only change the pressed pad's material
        padRenderer = GetComponent<Renderer>();
        yellow = new Color32(240, 230, 140, 125);
        red = new Color32(220, 20, 60, 125);
        green = new Color32(50, 205, 50, 125);
        defaultColor = new Color32(255, 255, 255, 125);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the pad wasn't already added to the list 
        if (!playerOrder.Contains(int.Parse(transform.name)))
        {
            //add it to the list  
            playerOrder.Add(int.Parse(transform.name));

            //changes the pads material to yellow uppon activation
            padRenderer.material.color = yellow;

            Debug.Log("Pad " + transform.name + " added!");

            //sequence is correct
            if (playerOrder.Count == correctOrder.Count && playerOrder.SequenceEqual(correctOrder))
            {
                Debug.Log("Sequencia Correta!");
                ChangePadsColor(parentObj, green);
                door.isDoorOpen = true;
                door1.isDoorOpen = true;
            }

            //sequence is incorrect
            else if (playerOrder.Count == correctOrder.Count && !playerOrder.SequenceEqual(correctOrder))
            {
                Debug.Log("Sequencia Errada");
                ChangePadsColor(parentObj, red);
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
        foreach (Transform child in parent.transform)
        {
            child.GetComponent<Renderer>().material.color = col;
        }
    }
}
