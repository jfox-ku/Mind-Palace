using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class HideableEncrypt : MonoBehaviour
{

    private static HideableEncrypt _instance;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        
    }

 
    public string EncryptAction(HideableAction act) {
        string r = "";
        string hash = act.GetActionString();
        string salt = CanvasManagerScript.GetInstance().currentSpace.spaceSalt;

        var sha512 = new SHA512Managed();
        byte[] result = sha512.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash+salt));
        r = Encoding.UTF8.GetString(result, 0, result.Length);
        return r;
    }


    public static HideableEncrypt GetEnc() {
        return _instance;
    }

}
