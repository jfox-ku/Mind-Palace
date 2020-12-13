using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideableMenuConnector : MonoBehaviour
{
    public Button UpButton;
    public Button DownButton;
    public Button HideButton;

    public HideableRoot CurrentHideable;

    public void DisplayFor(HideableRoot hd) {
        CurrentHideable = hd;

    }


    public void UpFunction() {
        CurrentHideable.AskToMove(1);
    }

    public void DownFunction() {
        CurrentHideable.AskToMove(-1);
    }

    public void DisableMe() {
        CurrentHideable.hasMenuOpen = false;
        CurrentHideable = null;
        HideableMenuManager.GetInstance().CloseMenu(this.gameObject);

    }


}
