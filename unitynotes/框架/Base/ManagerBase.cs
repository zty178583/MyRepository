using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBase : MonoBase {

    public static ManagerBase instance=null;

    protected Dictionary<string, MSGObjectBase> objects=new Dictionary<string, MSGObjectBase>();

    protected void Awake()
    {
        instance = this;
    }
    //接收信息
    public virtual void ReceiveMSG(MSGBase msg)
    {
        
    }
    public void Regisiter(string name,MSGObjectBase mSGObjeck)
    {
        if(objects.ContainsKey(name))
        {
            Debug.LogError("the name already exits"+name);
        }
        else
        {
            objects.Add(name, mSGObjeck);
        }
    }

}
