using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBase : MonoBehaviour {

    public string camp = "";
    public float HP=100;
    public float MP=100;
    public float damage=10;//攻击力
    public float defense=0;//防御力
    public float attack_speed = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Attack()
    {

    }
    public void Sufer(float damage)
    {
        
    }
}
