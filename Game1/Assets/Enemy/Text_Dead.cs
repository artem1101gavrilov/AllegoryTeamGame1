using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Text_Dead : MonoBehaviour
{
    public bool game_end = false;
    public string text_end;
    public Text end;
    public float time_end = 5;
    void Start()
    {

    }

    void Update()
    {
        end.text = text_end; //какой именно текст выводим на экран

        if (game_end == true) //если конец игры правда
        {
            time_end -= Time.deltaTime; //активация отсчета времени до перезапуска сцены
            if (time_end <= 0) //если счетчик равен или меньше нуля
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //перезапускаем текущую сцену
            }
        }
    }
}
