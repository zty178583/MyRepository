using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 飞行技能控制
/// </summary>
public class FlightSkillController : MonoBehaviour {
    private float damage;
    private string camp;
    public bool if_ontology=true;//是否是本体
    private void OnTriggerEnter(Collider other)
    {
        if (if_ontology)
            return;
        if (other.tag.Equals(camp))//自己人
            return;
        Soldier enemy_com_Soldier = other.GetComponent<Soldier>();
        if (enemy_com_Soldier != null)
            enemy_com_Soldier.Sufer(damage);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        if(!if_ontology)
            Destroy(gameObject, 2);
    }
    private void Awake()
    {
        Soldier soldier = GetComponentInParent<Soldier>();
        if (soldier == null)
            return;
        damage = soldier.damage;
        camp = soldier.camp;//防止误伤
    }
    // Update is called once per frame
    void Update () {
		
	}
}
