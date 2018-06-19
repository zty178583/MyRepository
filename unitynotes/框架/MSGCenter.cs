using Assets.Scripts.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGCenter :MonoBase{
    public static MSGCenter instance=null;
    private void Awake()
    {
        instance = this;
    }

    public void Transpond(MSGBase msg)
    {
        switch(msg.kind)
        {
            case ManagerKind.BTNManager:
                BTNManager.instance.ReceiveMSG(msg);
                break;
            case ManagerKind.UIManager:
                UIManager.instance.ReceiveMSG(msg);
                break;

            default:
                Debug.LogError("no manager you have appointed");
                break;
        }
            
        }


}
