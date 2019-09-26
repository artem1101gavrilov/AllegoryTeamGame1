using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_direction : MonoBehaviour
{
    //движение объекта к игроку

    GameObject player;

    public float speed = 1;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        float direction = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(direction) < 20)
        {
            Vector2 pos = transform.position;
            pos.x += Mathf.Sign(direction) * speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
