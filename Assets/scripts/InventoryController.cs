using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    public int inventorySize = 10;
    public int numberOfDistrib = 2;

    public SOItems[] listOfItem;

    public List<SOItemSlot> listItemSlotIsFull = new List<SOItemSlot>();



    private void Start()
    {
        UIInventoryPage.instance.InitializeInventoryUI(inventorySize);

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }       
    }

    public void GetRandomItems()
    {
        //On click --> prend un random / assigne l'image du prefab / set Active l'image
        
        int rnd = Random.Range(0, listOfItem.Length);

        for (int i = 0; i < inventorySize; i++) //7
        {
            if (!(listItemSlotIsFull.Count > i))
            {
                listItemSlotIsFull.Add(new SOItemSlot());
                print("created");
            }

            for (int j =0; j < numberOfDistrib; j++) //1

                if (listItemSlotIsFull[i].isFull == false)
                {
                    UIInventoryPage.instance.listOfUIItems[j].GetComponent<Image>().enabled = true;
                    listItemSlotIsFull[i].isFull = true;
                    UIInventoryPage.instance.listOfUIItems[j].GetComponent<Image>().enabled = true;
                }
        }
    }
}
