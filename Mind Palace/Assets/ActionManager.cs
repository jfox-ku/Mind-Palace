using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public DatabaseScript DatabaseRef;

    private static ActionManager _instance;
    public bool pickActive = false;
    public bool saveActive = false;
    public Queue<HideableRoot> Choices;
    const int neededChoiceCount = 2;

    string actionToUse;

    private void Awake() {
        Choices = new Queue<HideableRoot>();
        _instance = this;
    }

    public void ActivateSave() {
        saveActive = true;
    }

    
    public void ActivatePick(string act) {
        actionToUse = act;
        pickActive = true;
    }

    public void PutChoice(Transform hdbl) {
        HideableRoot obj = hdbl.GetComponent<HideableRoot>();
        if (obj == null) {
            Debug.LogError("Clicked object is not HideAble");
            return;
        }

        Choices.Enqueue(obj);
        CountCheck();
        

    }

    public void CountCheck() {
        if (Choices.Count >= neededChoiceCount) {
            HideableRoot root1 = Choices.Dequeue();
            HideableRoot root2 = Choices.Dequeue();

            HideableAction HAct = new HideableAction(root1,root2,actionToUse);

            HideableEncrypt.GetEnc().EncryptAction(HAct);

            //This data should be entered by user in UI
            HideableData data = new HideableData();
            data.Data = "suchsecretmuchwow";

            if (saveActive) {
                DatabaseRef.SendUserData(HAct, data);
            } else {
                DatabaseRef.PullUserData(HAct);

            }

            
            pickActive = false;
            saveActive = false;

        }
    }




    public static ActionManager GetInstance() {
        return _instance;
    }
}
