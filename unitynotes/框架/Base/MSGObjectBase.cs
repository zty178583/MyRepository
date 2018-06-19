using Assets.Scripts.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGObjectBase : MonoBase {

    public string token;
    public ManagerKind kind;
    public BehaviorBase[] behaviors;

    private void Awake()
    {
        behaviors = GetComponents<BehaviorBase>();
        MSGObjectHelper.Regisiter(kind,token,this);
    }

    public void ReceiveMSG(MSGBase msg)
    {
        foreach (var item in behaviors)
        {
            item.ReceiveMSG(msg);
        }
    }

    public void SendMSG(MSGBase msg)
    {
        MSGObjectHelper.SendMSG(kind,msg);
    }
}
