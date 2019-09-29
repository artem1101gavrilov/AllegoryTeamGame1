using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Text_Dead : MonoBehaviour
{
    public string text_end;
    public Text end;
    public float time_end = 5;
	
	private UnityAction someListener;
	
	void Awake()
    {
		//Создаем нашему действию определенную функцию при срабатывании событии - ActiveText
        someListener = new UnityAction(ActiveText);
    }
	
    void Start()
    {
        end.text = text_end; //какой именно текст выводим на экран
    }
	
	void OnEnable()
    {
		//Говорим менеджеру, что хоть получать события "Loser", выполняться будут действия someListener
        EventManager.StartListening("Loser", someListener);
    }

    void OnDisable()
    {
		//Отписываемся от события при уничтожении объекта
        EventManager.StopListening("Loser", someListener);
    }

	void ActiveText()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("Restart", time_end); //Invoke - выполняет метод Restart через time_end секунд
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
