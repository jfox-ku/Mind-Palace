using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoAssetManager : MonoBehaviour
{
    private static SoAssetManager _instance;

    [SerializeField]
    private HideableSO[] SOs;

    private static Dictionary<string, HideableSO> SODict;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        SODict = new Dictionary<string, HideableSO>();

        foreach (HideableSO hd in SOs) {
            SODict.Add(hd.uniqName,hd);

        }


    }

    public HideableSO GetFromUniqName(string uname) {
        return SODict[uname];
    }



    public SoAssetManager GetIntsnace() {
        return _instance;
    }
}
