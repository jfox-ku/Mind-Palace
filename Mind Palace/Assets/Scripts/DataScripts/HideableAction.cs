using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableAction 
{
    public HideableRoot root;
    public HideableRoot end;
    public string Action;


    public HideableAction(HideableRoot rt, HideableRoot en, string act) {
        root = rt;
        end = en;
        Action = act;
    }

    public string GetActionString() {

        return root.NameHdbl + Action + end.NameHdbl;
    }


}
