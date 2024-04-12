using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BinMannager : GameBehaviour
{
    TrashObjectScores trashObjectScores;


    public GameObject assigedPlayer;
    public int binCurrentScore;

    [SerializeField] int smallScore;
    [SerializeField] int midScore;
    [SerializeField] int bigScore;

    [SerializeField] List<GameObject> BinItemList = new List<GameObject>();
    [SerializeField] int maxListAmount;
    [SerializeField] Transform particalSpawnTransform;

    VFXManager vFXManager;
    

    private void Start()
    {
        vFXManager = _VFXM.GetComponent<VFXManager>();
        trashObjectScores = _GM.GetComponent<TrashObjectScores>();

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
                //print("Big Trash input");
                binCurrentScore += bigScore;
                AddToList(other.gameObject);
                break;

            case "MediumTrash":
                //print("Big Medium input");
                binCurrentScore += midScore;
                AddToList(other.gameObject);
                break;

            case "SmallTrash":
                //print("Big Small input");
                binCurrentScore += smallScore;
                AddToList(other.gameObject);
                break;
        }
        _UI.UpdateScoreText(binCurrentScore, assigedPlayer.GetComponent<PlayerController>().playerNum);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    switch (other.tag)
    //    {
    //        case "BigTrash":
    //            //print("Big Trash Exit");
    //            binCurrentScore -= bigScore;
    //            RemoveFromList(other.gameObject);
    //            break;

    //        case "MediumTrash":
    //            //print("Big Medium Exit");
    //            binCurrentScore -= midScore;
    //            RemoveFromList(other.gameObject);
    //            break;

    //        case "SmallTrash":
    //            //print("Big Small input");
    //            binCurrentScore -= smallScore;
    //            RemoveFromList(other.gameObject);
    //            break;
    //    }

    //    _UI.UpdateScoreText(binCurrentScore, assigedPlayer.GetComponent<PlayerController>().playerNum);
    //}

    private void checkDespawn()
    {
        if (BinItemList.Count >= maxListAmount + 1)
        {
            GameObject itemtoRemove = BinItemList[0];
            BinItemList.RemoveAt(0);
            itemtoRemove.SetActive(false);
        }
    }

    public void AddToList(GameObject item)
    {
        if (item != null)
        {
            BinItemList.Add(item);
            _DM.RemoveItemToDespawnList(item);
            _SC.RemoveItemToCollectList(item);

            checkDespawn();
            vFXManager.SpawnParticle(3, particalSpawnTransform);
        }
        else
        {
            print("wat");
        }
        
    }

    public void RemoveFromList(GameObject item)
    {
        if (item != null)
        {
            BinItemList.Remove(item);
            _DM.AddItemToDespawnList(item);
        }
        else
        {
            print("wat");
        }
    }


    public void Update()
    {
        
    }
}

    

