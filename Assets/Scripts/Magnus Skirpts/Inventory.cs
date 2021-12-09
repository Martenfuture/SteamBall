using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryObject;
    public Slot[] slots;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryObject.SetActive(!inventoryObject.activeInHierarchy);
        }
    }

    public void Additem(Item itemToBeAdded, Item startingItem = null)
    {
        foreach(Slot i in slots)
        {
            if(!i.slotsItem)
            {
                itemToBeAdded.transform.parent = i.transform;
                return;
            }
        }

    }

    void OnTriggerEnter (Collider col)
    {
        if(col.GetComponent<Item>())
            Additem(col.GetComponent<Item>());
    }
}
