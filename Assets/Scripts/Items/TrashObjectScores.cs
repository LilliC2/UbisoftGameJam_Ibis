using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObjectScores : MonoBehaviour
{
    public int[] smallTrashScore = { 10, 20, 40 }; // Small , Mid , Large
    public int trashAmount = 10;

    public int getScore(int trashIndex)
    {

        //returns the trash scores to all the bin scripts 
        return smallTrashScore[trashIndex];

    }

    public int getTrashAmout()
    {
        //returns the trash amount to all the bin scripts 
        return trashAmount;
    }
}
