using UnityEngine;
using UnityEngine.UI;

//this script handles the slot selection in the inventory
public class ButtonState : MonoBehaviour
{
    public bool isSlotSelected;
    public KeyCode keycode;
    private Button button;
    ColorBlock colorBlock;
    Color changeColor, defaultColor;

    void Start()
    {
        button = GetComponent<Button>();
        isSlotSelected = false;

        //set the default colorBlock
        colorBlock = GetComponent<Button>().colors;
        //lime green to change later
        defaultColor = Color.white;
        changeColor = new Color(0.3254902f, 0.8705882f, 0.3411765f);
    }

    void Update()
    {
        button.colors = colorBlock;

        if (isSlotSelected) colorBlock.normalColor = changeColor;
        else colorBlock.normalColor = defaultColor;

        //i know this is absolute hell but i was running out of patience and wanted to work or some other stuff
        //this switches the bool to false if any other slot is in use 
        //this decides which slot is selected uppon keycode click (1, 2, 3, 4)
        if (Input.GetKeyDown(keycode))
        {
            isSlotSelected = true;
        }
        else if (Input.anyKeyDown && !Input.GetKeyDown(keycode) &&
            !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S) &&
            !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D) &&
            !Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.Q)
            )
        {
            isSlotSelected = false;
        }
    }
}
