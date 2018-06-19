using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MSGObjectBase))]
public class BehaviorBase : MonoBase {

    public virtual void ReceiveMSG(MSGBase msg)
    {
        Debug.Log("没有重写ReceiveMSG");
    }
}
