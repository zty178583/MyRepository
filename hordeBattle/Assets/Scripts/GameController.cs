using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static List<GameObject> red_soldiers=new List<GameObject>();//红方士兵
    public static List<GameObject> blue_soldiers = new List<GameObject>();//绿方士兵
    
    void Start () {
        //寻找红蓝方士兵
        GameObject[] red = GameObject.FindGameObjectsWithTag(Tags.red_soldier);
        GameObject[] green = GameObject.FindGameObjectsWithTag(Tags.blue_soldier);

        //给list赋值
        foreach(GameObject current in red)
        {
            red_soldiers.Add(current);
        }
        foreach (GameObject current in green)
        {
            blue_soldiers.Add(current);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
