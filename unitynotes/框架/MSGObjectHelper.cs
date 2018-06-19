using Assets.Scripts.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGObjectHelper {

	public static void Regisiter(ManagerKind kind,string token,MSGObjectBase mSGObjeck)
    {
        switch (kind)
        {
            case ManagerKind.BTNManager:
                BTNManager.instance.Regisiter(token, mSGObjeck);
                break;
            case ManagerKind.UIManager:
                UIManager.instance.Regisiter(token, mSGObjeck);
                break;

            default:
                Debug.LogError("no manager you have appointed");
                break;
        }
    }
    public static void SendMSG(ManagerKind kind,MSGBase msg)
    {
        switch (kind)
        {
            case ManagerKind.BTNManager:
                BTNManager.instance.ReceiveMSG(msg);
                break;
            case ManagerKind.UIManager:
                UIManager.instance.ReceiveMSG(msg);
                break;

            default:
                Debug.LogError("no manager existed that you have appointed");
                break;
        }
    }
}
