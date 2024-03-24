using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEditor.Search;
using Inventory.UI;
using System;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryImage itemDescription;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    private void Awake()
    {
        //Hide();

        if (itemDescription != null )
        {
        itemDescription.ResetDescription();
        }
    }

    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
            uiItem.GetComponent<Image>().enabled = false;
        }
    }

    private void HandleShowItemActions(UIInventoryItem item)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem item)
    {
        
    }

    private void HandleSwap(UIInventoryItem item)
    {
        
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
        
    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        Debug.Log(this.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
