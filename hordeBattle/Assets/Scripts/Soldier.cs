using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : SoldierBase {

    public Texture2D blood_red;
    public Texture2D blood_black;
    public Soldier enemy_com_soldier;
    public GameObject enemy = null;
    public bool ifdead = false;
    private float max_hp;
	// Use this for initialization
	void Start () {
        //初始化
        max_hp = HP;
        camp = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0&&!ifdead)
        {
            Die();
        }
    }
    
    void OnGUI()
    {
        //绘制血条
        if(!ifdead&&HP<max_hp)
        {
            //计算模型高度
            float size_y = GetComponent<BoxCollider>().bounds.size.y+0.8f;
            float scal_y = transform.localScale.y;
            float model_height = size_y * scal_y;
            //得到模型头顶在3D世界中的坐标
            //默认模型坐标点在脚底下，所以这里加上npcHeight它模型的高度即可
            Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + model_height, transform.position.z);
            //根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
            Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
            //得到真实NPC头顶的2D坐标
            position = new Vector2(position.x, Screen.height - position.y);
            //计算出血条的宽高
            Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(blood_red));
            Vector2 scale_bloodsize = new Vector2(bloodSize.x * 0.4f, bloodSize.y * 0.2f);
            //通过血值计算红色血条显示区域
            float blood_width = blood_red.width * HP / 100;
            //先绘制黑色血条
            GUI.DrawTexture(new Rect(position.x - (scale_bloodsize.x / 2), position.y - scale_bloodsize.y, scale_bloodsize.x, scale_bloodsize.y), blood_black);
            //在绘制红色血条
            GUI.DrawTexture(new Rect(position.x - (scale_bloodsize.x / 2), position.y - scale_bloodsize.y, blood_width * 0.4f, scale_bloodsize.y), blood_red);
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
    public string GetEnemyTag()
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
    private void Die()
    {
        Destroy(gameObject.GetComponent<SphereCollider>());
        Destroy(gameObject.GetComponent<BoxCollider>());
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
        GetComponent<NavMeshAgent>().radius = 0;
        enemy = null;
        Destroy(gameObject, 5);
    }

}
