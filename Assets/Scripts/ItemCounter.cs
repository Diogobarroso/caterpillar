using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour, IDropHandler {

    GameObject manager;

    public void Start()
    {
        manager = GameObject.Find("GameManager");
        GetComponent<Text>().text = transform.childCount.ToString();
    }
    public GameObject item
    {
        get
        {
            if(transform.childCount>0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag.itemBeingDragged.transform.SetParent(transform);
        GetComponent<Text>().text = transform.childCount.ToString();
        manager.GetComponent<Manager>().checkOperation();
    }
}
