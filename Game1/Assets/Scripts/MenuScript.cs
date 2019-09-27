using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject AutorsMenu;
    public GameObject ControlMenu;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickGame()
    {
        SceneManager.LoadScene("Enemy_test");
    }
	
    public void ClickAutors()
    {
        MainMenu.active = false;
        AutorsMenu.active = true;
    }
	
    public void ClickControl()
    {
        MainMenu.active = false;
        ControlMenu.active = true;
    }
	
    public void ClickExit()
    {
        
    }
	
    public void ClickBack()
    {
        MainMenu.active = true;
        AutorsMenu.active = false;
        ControlMenu.active = false;
    }
}
