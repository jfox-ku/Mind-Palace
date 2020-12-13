using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HideableRoot : MonoBehaviour
{

    CanvasLayerScript CurrentParent;
    public bool hasMenuOpen = false;
    public string NameHdbl;

    // Start is called before the first frame update
    

    //Parents layer is same as our object. This is where using UI elements come in handy.
    //We can always know where anything is by asking its parent.
    public CanvasManagerScript.CanvasLayer GetParentsLayer() {
        CurrentParent = this.transform.parent.GetComponent<CanvasLayerScript>();
        if (CurrentParent == null) {
            Debug.LogError("Parent is not a CanvasLayer: "+this.transform.parent.name);
        }

        return CurrentParent.Layer;

    }

    public void AskToMove(int dir) {
        switch (dir) {
            case -1:
                CanvasManagerScript.GetInstance().PutMeDown(this.transform, GetParentsLayer());
                break;
            case 1:
                CanvasManagerScript.GetInstance().PutMeUp(this.transform, GetParentsLayer());
                break;
            default:
                Debug.LogError("Unknown dir: "+dir);
                break;
        }
    }


    public void SaveHideable() {
        SaveSystem.SaveHideable(this);
    }

    public void LoadHideable() {
        HideableRoot data = SaveSystem.LoadHideable();


    }





}
