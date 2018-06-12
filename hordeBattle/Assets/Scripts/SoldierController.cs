using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierController : MonoBehaviour {

    private Soldier enemy_com_soldier;
    public bool ifattack = false;
    private float attck_timer;//攻击计时器
    private Animator animator;
    private AIBehavior aiBehavior;
    private Soldier solider;
	// Use this for initialization
	void Start () {
        //初始化
        animator = GetComponent<Animator>();
        aiBehavior = GetComponent<AIBehavior>();
        solider = GetComponent<Soldier>();
        attck_timer = solider.attack_speed;
        //（找到敌人进行攻击）
        FindClosestAttack();
	}
    /// <summary>
    /// 碰撞触发
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (solider.enemy!=null&&other.tag.Equals(solider.GetEnemyTag()))//接触敌人
        {
            //停止导航和移动动画
            aiBehavior.StopNav();
            animator.SetBool(AnimatorPams.ifmove, false);
            ifattack = true;
        }
            
    }

	void OnTriggerExit(Collider other)
	{
        if(other.tag.Equals(solider.GetEnemyTag()))
        {
            ifattack = false;
            FindClosestAttack();
        }
	}
	private void FindClosestAttack()
    {
        //找到标签里最近的
        GameObject enemy = aiBehavior.GetClosestEnemy(solider.GetEnemyTag());
        if(enemy==null)
        {
            //TODO
            //胜利
            //animator.SetBool(AnimatorPams.ifidle, true);
            Debug.Log(solider.camp+"胜利！");
        }
        else
        {
            solider.enemy = enemy;
            aiBehavior.Nav2(enemy);
            animator.SetBool(AnimatorPams.ifmove, true);
            enemy_com_soldier = enemy.GetComponent<Soldier>();
        }
    }

    // Update is called once per frame
    void Update () {
        //刷新导航or攻击动画
        if(!ifattack)
        {
            if(solider.enemy!=null)
            {
                aiBehavior.Nav2(solider.enemy);
            }
            else
            {
                FindClosestAttack();
            }
        }

        //判断敌人是否死亡
        if (enemy_com_soldier != null&&enemy_com_soldier.ifdead)
            {
                animator.SetBool(AnimatorPams.ifidle, true); 
                solider.enemy = null;
                enemy_com_soldier = null;
                FindClosestAttack();

                ifattack = false;
            }
            
        if(ifattack)
        {
            if (attck_timer > 0)
            {
                attck_timer -= Time.deltaTime;
            }
            else
            {
                //攻击动画
                attck_timer += solider.attack_speed;
                animator.speed = 1.5f;
                animator.SetTrigger(AnimatorPams.attack);
                //攻击逻辑
                //Debug.Log("attack");
                solider.Attack();
            }
        }
        
	}
    void FixedUpdate()
    {
        if(solider.enemy!=null&&!solider.ifdead)
            aiBehavior.Lookat(solider.enemy);
    }
}
