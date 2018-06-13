using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIBehavior : MonoBehaviour {
    
    private NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    /// <summary>
    /// 导航到最近的敌人
    /// </summary>
    /// <param name="tag">敌人的tag</param>
    public void Nav2(GameObject target)
    {
        if(target!= null)
        {
            //开始导航
            nav.isStopped = false;
            nav.destination = target.transform.position;
            
        }

    }
    public void StopNav()
    {
        nav.isStopped = true;
    }
    //找到最近的敌人
    public GameObject GetClosestEnemy(string tag)
    {
        GameObject enemy = null;//找到的enemy
        if (tag.Equals(Tags.red_soldier))//红方
        {
            if(GameController.red_soldiers.Count>0)
                enemy = GameController.red_soldiers[0];
            foreach (GameObject soldier in GameController.red_soldiers)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) > Vector3.Distance(transform.position, soldier.transform.position))
                {
                    enemy = soldier;
                }
            }
        }
        else if (tag.Equals(Tags.blue_soldier))//蓝方
        {
            if (GameController.blue_soldiers.Count > 0)
                enemy = GameController.blue_soldiers[0];
            foreach (GameObject soldier in GameController.blue_soldiers)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) > Vector3.Distance(transform.position, soldier.transform.position))
                {
                    enemy = soldier;
                }
            }
        }
        return enemy;
    }

    public void Lookat(GameObject target)
    {
        Vector3 target_vector= target.transform.position-transform.position;
        Quaternion target_quaternion = Quaternion.LookRotation(target_vector);
        transform.rotation = Quaternion.Lerp(transform.rotation, target_quaternion, 0.1f);
    }
}
