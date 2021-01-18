using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HideableData 
{
    //Keeping the hash here probably creates a security flaw
    //This is here purely for database convinience and testing
    //The hash itself can't be a child in the database due to character issues
    public string Hash;


    public string Data;



}
