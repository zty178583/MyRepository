using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AIBehavior))]
[RequireComponent(typeof(Soldier))]
public class SoldierControllerBase : MonoBehaviour
{
    public Soldier enemy_com_soldier;
    private bool if_can_attack = false;
    public bool ifattack = false;
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

    }

    protected virtual void AIStart()
    {
        FindClosestAttack();
    }

    /// <summary>
    /// 碰撞触发
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (solider.ifdead)
            return;
        //TODO
        //接触敌人how？
        if (other.tag.Equals(solider.GetEnemyTag()))//接触敌人
        {
            aiBehavior.StopNav();
            if_can_attack = true;
            solider.enemy = other.gameObject;
            OnEnemyInAttackRange();
        }

    }

    protected void OnEnemyInAttackRange()
    {
        ifattack = true;
        animator.SetBool(AnimatorPams.ifmove, false);
    }

    void OnTriggerExit(Collider other)
    {
        if (solider.ifdead)
            return;
        //敌人离开攻击范围how?
        //TODO
        if (other.tag.Equals(solider.GetEnemyTag()))
        {
            if_can_attack = false;
            OnEnemyOutAttackRange();
        }
    }

    protected void OnEnemyOutAttackRange()
    {
        //ifattack = false;
        //找到最近的攻击
        FindClosestAttack();
    }

    //低级智能 找打最近的敌人进行攻击
    private void FindClosestAttack()
    {
        //找到标签里最近的
        GameObject enemy = aiBehavior.GetClosestEnemy(solider.GetEnemyTag());
        if (enemy == null)
        {
            //TODO
            //胜利
            //animator.SetBool(AnimatorPams.ifidle, true);
            Debug.Log(solider.camp + "胜利！");
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
    void Update()
    {
        if (solider.ifdead)
            return;
        AIUpdate();
        //判断敌人是否死亡
        if (enemy_com_soldier != null && enemy_com_soldier.ifdead)
        {
            enemy_com_soldier = null; solider.enemy = null;
            //TODO
            //敌人死亡后how？
            if_can_attack = false;
            OnEnemyDead();
        }
        //攻击速度控制逻辑    
        if (if_can_attack && ifattack)
        {
            if (attck_timer > 0)
            {
                attck_timer -= Time.deltaTime;
            }
            else
            {
                Attack();
                solider.Attack();
            }
        }

    }

    protected void Attack()
    {
        //攻击动画
        attck_timer += solider.attack_speed;
        animator.speed = 1.5f;
        animator.SetTrigger(AnimatorPams.attack);
        //攻击逻辑
        //Debug.Log("attack");

    }

    //敌人死亡后
    protected void OnEnemyDead()
    {
        animator.SetBool(AnimatorPams.ifidle, true);
        FindClosestAttack();
    }

    protected void AIUpdate_HaveEnemy()
    {
        aiBehavior.Nav2(solider.enemy);
    }

    protected void AIUpdate()
    {
        //检测是否有敌人
        if (solider.enemy != null)
        {
            //TODO
            AIUpdate_HaveEnemy();
        }
        else
        {
            //TODO
            //目前没有敌人how？
            AIUpdate_HaveNotEnemy();
        }
    }

    protected void AIUpdate_HaveNotEnemy()
    {
        FindClosestAttack();
    }

    void FixedUpdate()
    {
        if (solider.ifdead)
            return;
        AIFixedUpdate();
    }

    protected void AIFixedUpdate()
    {
        //转身
        if (solider.enemy != null)
            aiBehavior.Lookat(solider.enemy);
    }
}
