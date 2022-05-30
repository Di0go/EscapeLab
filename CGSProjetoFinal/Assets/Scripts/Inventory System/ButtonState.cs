using UnityEngine;

public class ButtonState : MonoBehaviour
{
    public bool isSelected = false;

    // switch on
    public void Switch()
    {
        if (!isSelected)
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
    }
}
