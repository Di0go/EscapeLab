using System.Collections.Generic;
using UnityEngine;

public class ResetSequence : PadManager
{
    private void OnCollisionEnter(Collision collision)
    {
        Reset(playerOrder);
    }

    //resets the player sequence
    private void Reset(List<int> list)
    {
        ChangePadsColor(parentObj, defaultColor);

        list.Clear();
    }
}
