using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WallBreakParticles : MonoBehaviour, IInteractable
{
    public float cubeSize = 20f;
    public int cubesInRow = 5;

    //inventory needs
    public Inventory inventory;
    public HUD hud;
    public GameObject neededObj;
    public Transform inventoryPanel;
    public GameObject vfx;

    private GameObject newObj;
    private RaycastHit hit;

    public Material mat0, mat1, mat2, mat3;

    void Start()
    {
        newObj = Instantiate(neededObj);
        newObj.SetActive(false);
    }

    public bool Interact(Interactor interactor)
    {
        IInventoryItem neededItem = neededObj.GetComponent<Bomb>();

        //remove the item from the hud
        //if player is holding the bomb 
        if (hud.SelectedItem() == neededItem)
        {
            //loop trough all the slots in the inventory
            foreach (Transform item in inventoryPanel)
            {
                //get the sprite that is in the slot (Slot -> Border -> Item)
                Image image = item.GetChild(0).GetChild(0).GetComponent<Image>();

                if (image.sprite == neededItem.Image)
                {
                    image.enabled = false;

                    image.sprite = null;

                    inventory.playerItems.Remove(neededItem);
                }
            }

            Destroy(neededObj);

            Physics.Raycast(interactor.transform.GetChild(0).position, Vector3.forward, out hit, 5.0f);

            newObj.SetActive(true);

            newObj.transform.position = hit.point;

            StartCoroutine(Countdown());

            return true;
        }

        return false;
    }

    //couroutine for the bomb countdown and material change
    private IEnumerator Countdown()
    {
        newObj.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat3;
        yield return new WaitForSeconds(1);

        newObj.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat2;
        yield return new WaitForSeconds(1);

        newObj.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat1;
        yield return new WaitForSeconds(1);

        newObj.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat0;
        yield return new WaitForSeconds(.25f);
        Instantiate(vfx, newObj.transform.position, newObj.transform.rotation);
        Destroy(newObj);
        explode();

    }

    public void explode() {
        Destroy(gameObject);


        //creates wall pieces
        for (int x = 0; x < cubesInRow; x++){
            for(int y = 0; y < cubesInRow; y++){
                for (int z = 0; z < cubesInRow; z++){
                    float r = Random.Range(1, 100);
                    float c;
                    if (r < 22) c = 1;
                    else c = 2;
                    createPiece(x, y, z, c);
                }
            }
        }
    }

    void createPiece(int x, int y, int z, float c) { //magic

        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z);
        piece.transform.localScale = new Vector3(cubeSize + 1.5f, cubeSize + 1.5f, cubeSize + 1.5f);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 20f;

        if(c == 1) piece.GetComponent<MeshRenderer>().material.color = new Color32(2, 0, 14, 255);
        else piece.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
    }
}
