using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Text_Dead text;
    public GameObject text_end;
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //если объект столкнулся с игроком
        {
                text_end.SetActive(true);  //то активируем объект, который будет выводить текст на экран
                text.game_end = true; //и посылаем команду другому скрипту, что конец игры это правда
        }
    }
}