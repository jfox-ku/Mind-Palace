using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FieldReader : MonoBehaviour
{

    [SerializeField] InputField emailI;
    [SerializeField] InputField passI;

    [SerializeField] Button sendButton;

    Authentication au;

    // Start is called before the first frame update
    void Start()
    {
        au = FindObjectOfType<Authentication>();
        if(au != null) {

            sendButton.onClick.AddListener(() => {au.ReadInputs(emailI,passI); au.SignIn();});
        }

    }

    private void OnDisable() {
        sendButton.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
