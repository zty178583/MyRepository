using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptileSoldierController : SoldierControllerBase {

    //protected override void AIStart()//初始化
    //{
        
    //}
    protected override void OnEnemyInAttackRange(Collider other)//取消行走动画
    {
        aiBehavior.StopNav();
        if_can_attack = true;//开始攻击计时
        solider.enemy = other.gameObject;
        animator.SetBool(AnimatorPams.ifmove, false);
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
        solider.Attack();
        animator.speed = 1.5f;
        animator.SetTrigger(AnimatorPams.attack);
    }
    protected override void FindedEnemy(GameObject enemy)//找到敌人该怎么做（导向，行走动画）
    {
        aiBehavior.Nav2(enemy);
        animator.SetBool(AnimatorPams.ifmove, true);
    }
    protected override GameObject FindEnemy()//返回找到的对象，找不到算赢了
    {
        GameObject enemy = aiBehavior.GetClosestEnemy(solider.GetEnemyTag());
        return enemy;
    }
}
