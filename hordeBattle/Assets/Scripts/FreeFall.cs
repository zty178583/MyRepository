using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoBehaviour
{
    public const float g = 9.8f;

    public GameObject target;
    public float speed = 10;
    private float verticalSpeed;
    void Start()
    {
        //计算模型高度
        float height = target.GetComponent<Collider>().bounds.size.y;
        Vector3 target_position = new Vector3(target.transform.position.x, target.transform.position.y+height/2, target.transform.position.z);

        float tmepDistance = Vector3.Distance(transform.position, target_position);
        float tempTime = tmepDistance / speed;
        float riseTime, downTime;
        riseTime = downTime = tempTime / 2;
        verticalSpeed = g * riseTime;

        transform.LookAt(target_position);
    }
    private float time;
    void Update()
    {
        if (transform.position.y < target.transform.position.y)
        {
            //finish
            return;
        }
        time += Time.deltaTime;
        float test = verticalSpeed - g * time;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        transform.Translate(transform.up * test * Time.deltaTime, Space.World);
    }
}
