using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : SoldierBase {
    public GameObject enemy = null;
    public bool ifdead = false;
	// Use this for initialization
	void Start () {
        camp = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0&&!ifdead)
        {
            die();
        }
    }
    /// <summary>
    /// 攻击敌人
    /// </summary>
    public new void Attack()
    {
        if(!ifdead)
        {
            var enemy_com_soldier = enemy.GetComponent<Soldier>();
            enemy_com_soldier.Sufer(damage);
        }
    }
    /// <summary>
    /// 承受伤害
    /// </summary>
    /// <returns>The sufer.</returns>
    /// <param name="damage">伤害</param>
    public new void Sufer(float damage)
    {
        HP -= (damage - defense);
    }
    /// <summary>
    /// 获得敌人标签
    /// </summary>
    /// <returns>The enemy tag.</returns>
    public string getEnemyTag()
    {
        if (camp.Equals(Tags.red_soldier))
            return Tags.blue_soldier;
        else if (camp.Equals(Tags.blue_soldier))
            return Tags.red_soldier;
        else
            return "";
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void die()
    {
        //死亡动画
        GetComponent<Animator>().SetTrigger(AnimatorPams.die);
        if (camp.Equals(Tags.blue_soldier))
        {
            GameController.blue_soldiers.Remove(gameObject);
        }
        else if (camp.Equals(Tags.red_soldier))
        {
            GameController.red_soldiers.Remove(gameObject);
        }
        ifdead = true;
        //GetComponent<SphereCollider>().isTrigger = false;//死亡后，胜者再次触发OntriggerEnter
        //GetComponent<SphereCollider>().isTrigger = false;
        //Destroy(gameObject.GetComponent<NavMeshAgent>());
        Destroy(gameObject.GetComponent<SphereCollider>());
        Destroy(gameObject.GetComponent<BoxCollider>());
        GetComponent<NavMeshAgent>().radius = 0;
        Destroy(gameObject, 5);
    }

}
