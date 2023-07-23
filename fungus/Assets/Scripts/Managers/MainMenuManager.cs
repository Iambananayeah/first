using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoInstance<MainMenuManager>
{
    public GameObject mainMenu;
    public GameObject hasChatImage;
    public Text sanText;
    public Text skillText;
    public Text sukiText;
    public Text moneyText;
    public Text popularText;
    public Text actPointsText;

    public Image roleSprite;

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
        Role role = RoleManager.Instance.role;
        sanText.text = "����    " + role.San.ToString();
        skillText.text = "�ݼ���    " + role.Skill.ToString();
        sukiText.text = "�øУ�    " + role.Suki.ToString();
        Circus circus = CircusManager.Instance.circus;
        moneyText.text = circus.Money.ToString();
        popularText.text = circus.Popular.ToString() + "/100";
        actPointsText.text = "�ж���:  "+circus.ActPoints.ToString();

        if(role.San>50)
        {
            string path = "Role/Lyric_light";
            Sprite sprite = Resources.Load<Sprite>(path);
            roleSprite.sprite = sprite;

        }
        //Debug.Log(RoleManager.Instance.role.hasChat);
    }

}
