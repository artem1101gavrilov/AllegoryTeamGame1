using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    //в общем встречайте мой очередной говнокод, но зато рабочий :) ПРИВЕТ ИЛЬЯ

    public int distance; //чем больше значение - тем больше времени объект будет двигаться в одну сторону
    float time; //отсчет времени
    int dir = 0; //изменение направления объекта и отсчета времени (в отрицательную или положительную сторону)
    // Start is called before the first frame update
    void Start()
    {
        if (dir==0) //присваиваем времени число дистанции и начинаем отсчитывать
        {
            time = distance;
            dir = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //1101: Вызывалось лишь однажды, нет смысла каждый раз проверять
        /*if (dir==0) //присваиваем времени число дистанции и начинаем отсчитывать
        {
            time = distance;
            dir = 1;
        }*/
        if (time >= distance) //больше этого числа нельзя, поэтому меняем направление объекта и отсчитываем время назад
        {
            dir = 1;
        }
        else if (time <= 0) //меньше этого числа нельзя, поэтому меняем направление объекта и отсчитываем время вперед
        {
            dir = 2;
        }
        if (dir == 1) //направляем объект влево и отсчитываем время до нуля
        {
            time -= Time.deltaTime;
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        else //направляем объект вправо и отсчитываем время до определенного числа
        {
            time += Time.deltaTime;
            transform.Translate(Vector2.right * Time.deltaTime);
        }
    }
}
