using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSoldierController : SoldierControllerBase {

    public GameObject target;
    //protected override void AIStart()//初始化
    //{

    //}
    protected override void OnEnemyInAttackRange(Collider other)//决定是否攻击（ifattack）取消行走动画
    {
        //Debug.Log("攻击");
        //animator.SetBool(AnimatorPams.ifmove, false);
        //aiBehavior.StopNav();
        if_can_attack = true;//开始攻击计时
        solider.enemy = other.gameObject;
    }
    //protected override void OnEnemyOutAttackRange(Collider other)//没啥用
    //{

    //}
    //protected override void AIFixedUpdate()//默认转向敌人
    //{

    //}
    //protected override void OnEnemyDead()//没啥用
    //{

    //}
    protected override void Attack()//攻击 调用soldier攻击
    {
        animator.speed = 1.5f;
        //Debug.Log("攻击");
        animator.SetTrigger(AnimatorPams.attack);
        Invoke("DelayPlay", 0.25f);
    }
    protected override void FindedEnemy(GameObject enemy)//找到敌人该怎么做（导向，行走动画）
    {
        //aiBehavior.Nav2(enemy);
        //animator.SetBool(AnimatorPams.ifmove, true);
    }
    protected override GameObject FindEnemy()//返回找到的对象，找不到算赢了
    {
        //GameObject enemy = aiBehavior.GetClosestEnemy(solider.GetEnemyTag());
        return target;
    }
    private void DelayPlay()
    {
        //GameObject fire_ball = GameObject.FindGameObjectWithTag("fireball");
        GameObject fire_ball = GetComponentInChildren<FlightSkillController>().gameObject;
        GameObject new_fireball = Instantiate(fire_ball, fire_ball.transform);
        new_fireball.transform.SetParent(null);
        new_fireball.AddComponent<FreeFall>().target = solider.enemy;
    }
}
