using UnityEngine;
using System.Collections.Generic;

public class Sequence : MonoBehaviour
{
    static protected List<int> correctOrder;

    static protected List<int> playerOrder;

    void Start()
    {
        //defines the correct order for the sequence
        correctOrder = new List<int> {3, 6, 1, 7, 2, 5, 4, 9, 8};
        //1, 2, 3, 4, 5, 6, 7, 8, 9          

        //this list is used to store the sequence chosen by the player
        playerOrder = new List<int>();
    }
}