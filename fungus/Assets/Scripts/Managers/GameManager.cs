using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoInstance<GameManager>
{
    public Action onGameStart;
    public ERoles role;
    public override void init()
    {
        base.init();
    }

    public void GameStart()
    {
        if(onGameStart!=null)
        onGameStart();
        SceneManager.LoadScene("Start Guide");
    }
}
