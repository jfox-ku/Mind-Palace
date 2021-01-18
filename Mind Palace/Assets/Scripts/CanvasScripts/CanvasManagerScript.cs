using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CanvasManagerScript;

public class CanvasManagerScript : MonoBehaviour
{
    public static CanvasManagerScript _instance;

    public enum CanvasLayer { Background,Back, Middle,Front}

    public SpaceScript currentSpace;
    public Transform FrontCanvas;
    public Transform BackCanvas;
    public Transform MiddleCanvas;
    public Transform BackgroundCanvas;

    CanvasLayer MyLayer;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSpace(SpaceScript SS) {
        if (currentSpace != null) {
            currentSpace.gameObject.SetActive(false);
        }
        currentSpace = SS;
        this.FrontCanvas = SS.FrontCanvas;
        this.BackCanvas = SS.BackCanvas;
        this.MiddleCanvas = SS.MiddleCanvas;
        this.BackgroundCanvas = SS.BackgroundCanvas;
    }

    public void PutMeUp(Transform obj,CanvasLayer current) {
        PutMeHere(obj,EnumHelperExtension.Move(current,1));
    }

    public void PutMeDown(Transform obj, CanvasLayer current) {
        PutMeHere(obj, EnumHelperExtension.Move(current, -1));
    }

    public void PutMeHere(Transform obj,CanvasLayer cv) {
        Transform parent;
        switch (cv) {
            case CanvasLayer.Back:
                parent = BackCanvas;
                break;
            case CanvasLayer.Front:
                parent = FrontCanvas;
                break;
            case CanvasLayer.Middle:
                parent = MiddleCanvas;
                break;
            case CanvasLayer.Background:
                parent = BackgroundCanvas;
                break;
            default:
                parent = BackgroundCanvas;
                break;
        }

        obj.SetParent(parent);

    }


    public static CanvasManagerScript GetInstance() {
        if (_instance == null) Debug.LogError("Canvas manager is null");
        return _instance;
    }


   


}
