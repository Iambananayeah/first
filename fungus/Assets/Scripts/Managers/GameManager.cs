using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGameState
{
    GameStartMenu,
    GameStartGuide,
    GameMainMenu,
    Dialogue,

}

public class GameManager : MonoInstance<GameManager>
{
    //public Action onGameStart;
    public EGameState state;


    public override void init()
    {
        base.init();
       // mainMenu = GameObject.Find();
    }

    public void StartNewGame()
    {
        /*if(onGameStart!=null)
        onGameStart();*/
        SceneManager.LoadScene("NewGame Guide");
    }

    public void NewGameInit(ERoles role)
    {
       // RoleManager.Instance.role = new Role(role,null);
    }



}
