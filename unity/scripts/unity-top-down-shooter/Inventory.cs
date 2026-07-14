using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private List<GameObject> items;
    void Update()
    {
        AddAllItemsInInventoryToList();

        if(Input.GetKey(KeyCode.Alpha1))
        {
            Select("SMG");
        }
        
        if(Input.GetKey(KeyCode.Alpha2))
        {
            Select("Shotgun");
        }
    }
    void Select(string itemToSearch)
    {
        foreach(GameObject item in items){
            item.SetActive(false);
            if(item.name == itemToSearch){
                item.SetActive(true);
            }
        }
    }

    void AddAllItemsInInventoryToList()
    {
        for(int i = 1; i <= gameObject.transform.childCount; i++)
        {
            if(!items.Contains(gameObject.transform.GetChild(i-1).gameObject)) //-1 is used bc GetChild index starts from 0
            {
                items.Add(gameObject.transform.GetChild(i-1).gameObject);
            }
        }
    }
}
