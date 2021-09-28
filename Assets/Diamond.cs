using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour, ICollectable
{
    DiamondManager diamondManager;
    Camera gameCamera;
    Transform thisObj;

    bool isPickUp;
    void Start()
    {
        diamondManager = FindObjectOfType<DiamondManager>();
    }
    void Update()
    {
        if (isPickUp)
        {
            //TODO INSTANTİATE IMAGE AND SEND İT TO RİGHT TOP Uİ
        }
    }
    public void Collect()
    {
        diamondManager.Add();
        isPickUp = true;
        Destroy(this.gameObject);
    }
}
