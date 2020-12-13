using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   
    public static void SaveHideable(HideableRoot hdb) {

        BinaryFormatter fr = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saved.hdb";
        FileStream stream = new FileStream(path, FileMode.Create);


        fr.Serialize(stream,hdb);
        stream.Close();
    }


    public static HideableRoot LoadHideable() {
        string path = Application.persistentDataPath + "/saved.hdb";
        if (File.Exists(path)) {
            BinaryFormatter fr = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HideableRoot rt = fr.Deserialize(stream) as HideableRoot;
            return rt;



        } else {
            Debug.LogError("Save file not foudn in "+path);
            return null;
        }


    }

}
