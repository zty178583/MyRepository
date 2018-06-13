using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 飞行技能控制
/// </summary>
public class FlightSkillController : MonoBehaviour {
    private float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == null || other.tag.Equals(""))
            return;
        Soldier enemy_com_Soldier = other.GetComponent<Soldier>();
        if (enemy_com_Soldier != null)
            enemy_com_Soldier.Sufer(damage);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        
    }
    private void Awake()
    {
        damage = GetComponentInParent<Soldier>().damage;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
