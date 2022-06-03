using UnityEngine;
using UnityEngine.UI;

//credits to: https://www.youtube.com/watch?v=THmW4YolDok
//this class will create a sphere that detects and "caches" collisions
//it also handles the UI component of this script

public class Interactor : MonoBehaviour
{
    //this array will store all interactable objects in range
    private Collider[] colliders = new Collider[3];

    //create an empty object and make him a child of the player,
    //position the point where you want the collision detecting sphere to work
    [SerializeField] private Transform intPoint;
    //create and select the desired mask
    [SerializeField] private LayerMask intMask;
    //UI to interact when object is nearby
    [SerializeField] private SpriteRenderer intUI;

    private float intPointRadius;
    public int intNum;

    private void Start()
    {
        intPointRadius = 1.5f;
    }

    private void Update()
    {
        //this creates the sphere that detects collisions with objects of layer intMask and stores them in an array
        intNum = Physics.OverlapSphereNonAlloc(intPoint.position,intPointRadius, 
            colliders, intMask);

        //show UI switch
        bool showUI = false;

        //when interactable object is found
        if (intNum > 0)
        {
            //creates new interactable object from the colliders array
            IInteractable interactable = colliders[0].GetComponent<IInteractable>();

            //if object isn't null
            if (interactable != null)
            {
                //input pressed
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //interact with object 
                    interactable.Interact(this);
                    showUI = false;
                } 
                else
                {
                    //saves the Y mesh bounds and multiplies it by 2
                    float meshY = interactable.transform.GetChild(0).GetComponent<MeshFilter>().mesh.bounds.max.y * 2;

                    //sets the UI's position to the interactable's obj position and sums the Y value with the mesh bounds
                    //so the UI appears on top of the object
                    intUI.transform.localPosition = 
                        new Vector3
                        (interactable.transform.position.x,         //X position for the UI
                        interactable.transform.position.y + meshY,  //Y position for the UI
                        interactable.transform.position.z);         //Z position for the UI

                    //locks the UI's rotation to the main camera's rotation
                    intUI.transform.rotation = Camera.main.transform.rotation;

                    //switch showUI to true if object is in range but no buttons are pressed
                    showUI = true;
                }
            }
        }
        //switch between showing UI according to the showUI variable defined above
        intUI.enabled = showUI;
    }
}
