using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinMannager : MonoBehaviour
{
    [SerializeField] TrashObjectScores trashObjectScores;


    [SerializeField] GameObject assigedPlayer;
    [SerializeField] int binCurrentScore;

    [SerializeField] int smallScore;
    [SerializeField] int midScore;
    [SerializeField] int bigScore;

    [SerializeField] List<GameObject> BinItemList = new List<GameObject>();
    [SerializeField] int maxListAmount;
    [SerializeField] DespawnMannager despawnMannager;

    private void Start()
    {
        smallScore = trashObjectScores.getScore(0);
        midScore = trashObjectScores.getScore(1);
        bigScore = trashObjectScores.getScore(2);
        maxListAmount = trashObjectScores.getTrashAmout();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "BigTrash":
                print("Big Trash input");
                binCurrentScore += bigScore;
                AddToList(other.gameObject);
                break;

            case "MediumTrash":
                print("Big Medium input");
                binCurrentScore += midScore;
                AddToList(other.gameObject);
                break;

            case "SmallTrash":
                print("Big Small input");
                binCurrentScore += smallScore;
                AddToList(other.gameObject);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "BigTrash":
                print("Big Trash Exit");
                binCurrentScore -= bigScore;
                RemoveFromList(other.gameObject);
                break;

            case "MediumTrash":
                print("Big Medium Exit");
                binCurrentScore -= midScore;
                RemoveFromList(other.gameObject);
                break;

            case "SmallTrash":
                print("Big Small input");
                binCurrentScore -= smallScore;
                RemoveFromList(other.gameObject);
                break;
        }
    }

    private void checkDespawn()
    {
        if (BinItemList.Count >= maxListAmount + 1)
        {
            GameObject itemtoRemove = BinItemList[0];
            BinItemList.RemoveAt(0);
            itemtoRemove.SetActive(false);
        }
    }

    private void AddToList(GameObject item)
    {
        if (item != null)
        {
            BinItemList.Add(item);
            despawnMannager.RemoveItemToDespawnList(item);
            checkDespawn();
        }
        else
        {
            print("wat");
        }
        
    }

    private void RemoveFromList(GameObject item)
    {
        if (item != null)
        {
            BinItemList.Remove(item);
            despawnMannager.AddItemToDespawnList(item);
        }
        else
        {
            print("wat");
        }
    }

    public void GetScoreFromBin()
    {

    }
}

    

