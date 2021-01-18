using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;

public class DatabaseScript : MonoBehaviour {
    public Authentication au;
    private FirebaseDatabase _database;
    public DatabaseReference reference;


    private void Start() {

        reference = FirebaseDatabase.GetInstance("https://mind-palace-ku2020-default-rtdb.firebaseio.com/").RootReference;
        Debug.Log(reference.Child("Data").Key);
    }




    public void SendUserData(HideableAction act, HideableData data) {

        string hash = HideableEncrypt.GetEnc().EncryptAction(act);
        data.Hash = hash;
        Debug.Log("Hash is :"+ hash);

        _database = reference.Database;
        DatabaseReference ref1 = _database.RootReference.Child("Data").Child(au.GetUserUniq()).Push();
        Debug.Log(ref1.ToString());

        ref1.SetRawJsonValueAsync(JsonUtility.ToJson(data)).ContinueWith(task => {
            if (task.IsCompleted) Debug.Log("Data sent to " + ref1.ToString() + " ");
        });

    }



    public void PullUserData(HideableAction act) {
        
        string hash = HideableEncrypt.GetEnc().EncryptAction(act);

        reference.Child(au.GetUserUniq()).GetValueAsync().ContinueWith(task => {
            DataSnapshot snapshots = task.Result;

           

                string pull = snapshots.Child(hash).GetRawJsonValue();

                HideableData hdata = JsonUtility.FromJson<HideableData>(pull);

                Debug.Log("Pulled " + pull);
            




        });



    }

}
