using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventoryImage : MonoBehaviour
    {
        [SerializeField]
        private Image itemImage;
        [SerializeField]
        private TMP_Text title;
        [SerializeField]
        private TMP_Text description;


        public void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            if (itemImage != null)
            {
                itemImage.gameObject.SetActive(false);
            }

            if(title != null && description != null) 
            {
            title.text = "";
            description.text = "";        
            }
        }

        public void SetDescription(Sprite sprite, string itemName,
            string itemDescription)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            if (title != null && description != null)
            {
                title.text = itemName;
                description.text = itemDescription;
            }
        }
    }
}