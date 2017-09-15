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

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name.Contains ("Object"))
			SetDistance (col);
			
	}

	private void SetDistance(Collision col)
	{
		Vector3 thisObj = transform.localPosition;
		Vector3 otherObj = col.transform.localPosition;
		float dist = Vector3.Distance (this.transform.localPosition, col.transform.localPosition);
		float distx = Math.Abs (thisObj [0] - otherObj [0]);
		float disty = Math.Abs (thisObj [1] - otherObj [1]);
		if (this.transform.localPosition.x < col.transform.localPosition.x)
			thisObj [0] = thisObj [0] - distx;
		else if (this.transform.localPosition.x > col.transform.localPosition.x)
			thisObj [0] = thisObj [0] + distx;
		if (this.transform.localPosition.y < col.transform.localPosition.y)
			thisObj [1] = thisObj [1] - disty;
		else if (this.transform.localPosition.y > col.transform.localPosition.y)
			thisObj [1] = thisObj [1] + disty;
		
	}
}
