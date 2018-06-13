using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : SoldierBase {

    public float hp_offset=-1.8f;
    public Texture2D blood_red;
    public Texture2D blood_black;
    private float max_hp;
	// Use this for initialization
	void Start () {
        //初始化
        max_hp = HP;
        camp = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
        if(enemy!=null)
            enemy_com_soldier = enemy.GetComponent<Soldier>();
    }
    void OnGUI()
    {
        //绘制血条
        if(!ifdead&&HP<max_hp)
        {
            //计算模型高度
            float size_y = GetComponent<SphereCollider>().bounds.size.y+ hp_offset;
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
    /// 死亡
    /// </summary>
    public void Die()
    {
        Destroy(gameObject.GetComponent<SphereCollider>());
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
        NavMeshAgent nm = GetComponent<NavMeshAgent>();
        nm.radius = 0;
        nm.height = 0;
        enemy = null;
        Destroy(gameObject, 5);
    }

}
