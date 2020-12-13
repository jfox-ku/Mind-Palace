using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableMenuManager : MonoBehaviour
{
    public static HideableMenuManager _instance;
    public List<HideableMenuConnector> MenusList;
    public const int MAX_CONNECTOR = 10;

    public GameObject MenuPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        MenusList = new List<HideableMenuConnector>();

        for(int i=0; i< MAX_CONNECTOR; i++) {
            var obj = Instantiate(MenuPrefab,this.transform);
            obj.SetActive(false);
            MenusList.Add(obj.GetComponent<HideableMenuConnector>());
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenForHideable(HideableRoot obj) {
        HideableMenuConnector menu = this.GetUnused();
        menu.transform.position = obj.transform.position;
        menu.DisplayFor(obj);
        menu.gameObject.SetActive(true);

    }

    public void CloseMenu(GameObject menu) {
        menu.SetActive(false);

    }

    public static HideableMenuManager GetInstance() {
        if (_instance == null) Debug.LogError("Canvas manager is null");
        return _instance;
    }

    public HideableMenuConnector GetUnused() {
        
        foreach(HideableMenuConnector hd in MenusList) {
            if (hd.gameObject.activeInHierarchy) continue;
            else return hd;

        }
        Debug.LogError("No inactive Menu found.");
        return null;
    }



}
