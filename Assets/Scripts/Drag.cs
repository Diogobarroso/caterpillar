using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 start;
    Transform startParent;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startParent = transform.parent;
        start = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        if (transform.parent != startParent)
            transform.position = start;
        //GameObject.Find("GameManager").GetComponent<Manager>().checkOperation();
    }
}
