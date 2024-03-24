using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool isTrash;
    private GameObject item;
 
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        if (isTrash == true) {
            Debug.Log("Delete");
            item = eventData.pointerDrag.gameObject;
            StartCoroutine(WaitBeforeDestroyRoutine(.5f));
        }
    }

    public void DestroyItem() {
        if (item != null) {
           Destroy(item); 
        }
    }

    IEnumerator WaitBeforeDestroyRoutine(float duration)
    {
        Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
        yield return new WaitForSeconds(duration);
        Debug.Log($"Ended at {Time.time}"); 
        DestroyItem();
    }
}
