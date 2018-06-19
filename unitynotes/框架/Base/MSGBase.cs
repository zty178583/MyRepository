using Assets.Scripts.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGBase {

    public string from;
    public ManagerKind kind;
    public string to;
    public string OPCode;

    public MSGBase()
    {

    }
    public MSGBase(string from,ManagerKind kind,string to,string OPCode)
    {
        this.from = from;
        this.kind = kind;
        this.to = to;
        this.OPCode = OPCode;
    }
}
