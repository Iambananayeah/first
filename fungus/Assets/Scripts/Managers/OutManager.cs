using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutManager : MonoInstance<OutManager>
{
    public GameObject outBG;
    public GameObject outUI;
    public GameObject medicalMenu;
    public void TryShowOut()
    {

    }
    public void ShowOut()
    {
        MainMenuManager.Instance.UnShowMainMenu();
        outBG.SetActive(true);
        outUI.SetActive(true);
    }

    public void ShowMecical()
    {
       // medicalMenu.SetActive(true);
    }

    public void GoHome()
    {
        outBG.SetActive(false);
        outUI.SetActive(false);
        MainMenuManager.Instance.ShowMainMenu();
    }

    public void setStagePos()
    {
       
        GameObject stageLeft = GameObject.Find("Right");
        stageLeft.transform.position = new Vector3(stageLeft.transform.position.x,-500f,stageLeft.transform.position.z);
        //fox.transform.position = new Vector3(fox.transform.position.x,-1700f,fox.transform.position.z);
       
    }

    public void setRoleSize()
    {
        GameObject fox = GameObject.Find("fox holder");
        fox.transform.localScale = new Vector3(2.2f, 2.2f, 1);
    }
}
