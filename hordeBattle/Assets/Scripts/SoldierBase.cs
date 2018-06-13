using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBase : MonoBehaviour {
    public GameObject enemy;
    public bool ifdead;
    public string camp = "";
    public float HP=100;
    public float MP=100;
    public float damage=10;//攻击力
    public float defense=0;//防御力
    public float attack_speed = 1.5f;
    public SoldierBase enemy_com_soldier;
    /// <summary>
    /// 获得敌人标签
    /// </summary>
    /// <returns>The enemy tag.</returns>
    public virtual string GetEnemyTag()
    {
        if (camp.Equals(Tags.red_soldier))
            return Tags.blue_soldier;
        else if (camp.Equals(Tags.blue_soldier))
            return Tags.red_soldier;
        else
            return "";
    }
    /// <summary>
    /// 攻击敌人
    /// </summary>
    public virtual void Attack()
    {
        if (!ifdead)
        {
            enemy_com_soldier.Sufer(damage);
        }
    }
    /// <summary>
    /// 承受伤害
    /// </summary>
    /// <returns>The sufer.</returns>
    /// <param name="damage">伤害</param>
    public virtual void Sufer(float damage)
    {
        HP -= (damage - defense);
    }
}
