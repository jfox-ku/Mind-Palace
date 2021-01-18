using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static CanvasManagerScript;

public class DraggableScript : MonoBehaviour, IPointerDownHandler, 
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {
    public HideableRoot myObject;
    private bool dragging = false;

  


    //Instantiated in the unity editor. Points to itself.
    public Transform rootObject;
    
    private void Awake() {
        myObject = this.GetComponent<HideableRoot>();
        if (myObject == null) {
            Debug.LogError("Draggable needs a root: "+this.gameObject.name);
        }
    }


    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Drag Begin");
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("Dragging");
        rootObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("Drag Ended");
        dragging = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (ActionManager.GetInstance().pickActive) {
            ActionManager.GetInstance().PutChoice(rootObject);
        }

        if (dragging) return;
        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject) {
            if (!myObject.hasMenuOpen) {
                //Debug.Log("Opening menu for " + this.gameObject.name);
                HideableMenuManager.GetInstance().OpenForHideable(myObject);
                myObject.hasMenuOpen = true;
            }

        }


        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }


    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        //Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData) {
        //Debug.Log("Mouse Up");
    }



}
