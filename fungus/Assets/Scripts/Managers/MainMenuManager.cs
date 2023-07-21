using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoInstance<MainMenuManager>
{
    public GameObject mainMenu;
    public GameObject hasChatImage;

    public override void init()
    {
        base.init();  
    }

    private void Start()
    {
        ShowMainMenu();
    }

    public void UnShowMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        hasChatImage.SetActive(RoleManager.Instance.role.hasChat);
        Debug.Log(RoleManager.Instance.role.hasChat);
    }
}
