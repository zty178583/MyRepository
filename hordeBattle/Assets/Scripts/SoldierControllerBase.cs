using System;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AIBehavior))]
[RequireComponent(typeof(Soldier))]
public class SoldierControllerBase : MonoBehaviour
{
    protected bool if_can_attack = false;
    protected float attck_timer;//攻击计时器
    protected Animator animator;
    protected AIBehavior aiBehavior;
    protected Soldier solider;

    // Use this for initialization
    void Start()
    {
        //初始化
        animator = GetComponent<Animator>();
        aiBehavior = GetComponent<AIBehavior>();
        solider = GetComponent<Soldier>();
        attck_timer = solider.attack_speed;
        //（找到敌人进行攻击）
        //TODO
        //开始how？
        AIStart();
        StartAIBehavior();
    }

    protected virtual void AIStart()
    {
        
    }

    /// <summary>
    /// 碰撞触发
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (solider==null||solider.ifdead)
            return;
        if (Vector3.Distance(transform.position, other.gameObject.transform.position) > GetComponent<SphereCollider>().radius)
            return;
        //TODO
        //接触敌人how？
        if (other.tag.Equals(solider.GetEnemyTag()))//接触敌人
        {
            
            OnEnemyInAttackRange(other);
        }

    }

    protected virtual void OnEnemyInAttackRange(Collider other)
    {
        //ifattack = true;
        //animator.SetBool(AnimatorPams.ifmove, false);
    }

    void OnTriggerExit(Collider other)
    {
        if (solider==null||solider.ifdead)
            return;
        //敌人离开攻击范围how?
        //TODO
        if (other.tag.Equals(solider.GetEnemyTag()))
        {
            if_can_attack = false;
            OnEnemyOutAttackRange(other);
            StartAIBehavior();
        }
    }

    protected virtual void OnEnemyOutAttackRange(Collider other)
    {

    }

    //开始智能行为
    private void StartAIBehavior()
    {
        //找到标签里最近的
        GameObject enemy=FindEnemy();
        if (enemy == null)
        {
            //TODO
            //胜利
            animator.SetBool(AnimatorPams.ifidle, true);
            Debug.Log(solider.camp + "胜利！");    
        }
        else
        {
            FindedEnemy(enemy);

        }
    }

    protected virtual void FindedEnemy(GameObject enemy)
    {
        //aiBehavior.Nav2(enemy);
        //animator.SetBool(AnimatorPams.ifmove, true);
    }

    protected virtual GameObject FindEnemy()
    {
        //GameObject enemy = aiBehavior.GetClosestEnemy(solider.GetEnemyTag());
        //return enemy;
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (solider.ifdead)
            return;
        if (solider.HP<0)
        {
            solider.Die();
            return;
        }
            
        AIUpdate();
        //判断敌人是否死亡
        if (solider.enemy_com_soldier != null && solider.enemy_com_soldier.ifdead)
        {
            solider.enemy_com_soldier = null; solider.enemy = null;
            //TODO
            //敌人死亡后how？
            if_can_attack = false;
            OnEnemyDead();
            StartAIBehavior();
        }
        //攻击速度控制逻辑    
        if (if_can_attack)
        {
            if (attck_timer > 0)
            {
                attck_timer -= Time.deltaTime;
            }
            else
            {
                if(solider.enemy!=null)
                {   
                    attck_timer += solider.attack_speed;
                    Attack();
                }

            }
        }

    }

    protected virtual void Attack()
    {
        //攻击动画
        //animator.speed = 1.5f;
        //animator.SetTrigger(AnimatorPams.attack);
        //攻击逻辑
        //Debug.Log("attack");

    }

    //敌人死亡后
    protected virtual void OnEnemyDead()
    {
        animator.SetBool(AnimatorPams.ifidle, true);
    }

    private void AIUpdate()
    {
        //检测是否有敌人
        if (solider.enemy == null)
        {
            //目前没有敌人how？
            StartAIBehavior();
        }
    }

    void FixedUpdate()
    {
        if (solider.ifdead)
            return;
        AIFixedUpdate();
    }

    protected virtual void AIFixedUpdate()
    {
        //转身
        if (solider.enemy != null)
            aiBehavior.Lookat(solider.enemy);
    }
}
