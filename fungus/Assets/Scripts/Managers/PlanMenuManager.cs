using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanMenuManager : MonoInstance<PlanMenuManager>
{
    public GameObject planMenuBG;
    public GameObject planMenuUI;

    public GameObject planMain;
    public Text sanText;
    public Text skillText;
    public Text sukiText;
    public GameObject showMenu;
    public void ShowPlanMenu()
    {
        MainMenuManager.Instance.UnShowMainMenu();
        ShowPlanMenuBG();
        ShowPlanMenuUI();
        Role role = RoleManager.Instance.role;
        sanText.text = "精神：" + role.San.ToString();
        skillText.text = "演技：" + role.Skill.ToString();
        sukiText.text = "好感：" + role.Suki.ToString();
        planMain.SetActive(true);
    }

    protected void ShowPlanMenuBG()
    {
        planMenuBG.SetActive(true);
    }

    protected void ShowPlanMenuUI()
    {
        planMenuUI.SetActive(true);
    }

    public void ShowShowMenu()
    {
        planMain.SetActive(false);
        showMenu.SetActive(true);
    }

    public void Back()
    {
        if(showMenu.activeSelf)
        {
            planMain.SetActive(true);
            showMenu.SetActive(false);
        }
        else if(planMain.activeSelf)
        {
            planMenuBG.SetActive(false);
            planMenuUI.SetActive(false);
            MainMenuManager.Instance.ShowMainMenu();
        }
    }
    public void ShowStart()
    {
        showMenu.SetActive(false);
    }
    public void EndShow()
    {
        ShowPlanMenu();
    }

}
