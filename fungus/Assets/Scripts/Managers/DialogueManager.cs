using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EDialogueType
{ 
    RoleTalk=1,

}

public class DialogueManager : MonoInstance<DialogueManager>
{
    // Start is called before the first frame update

    public GameObject diaBG;
    public GameObject diaMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterDialogue()
    {

        EnterDialogue(1);
    }
    public void EnterDialogue(int dialogueType=1)
    {
        EDialogueType type = (EDialogueType)dialogueType;
       /* if(type==EDialogueType.RoleTalk)
        {
            RoleManager.Instance.role.hasChat = false;
        }*/

        MainMenuManager.Instance.UnShowMainMenu();//to do 
        Invoke("ShowDialogueBG", 0.5f);

    }

    public void TryEnterDialogue()
    {

    }

    public void ExitDialogue()
    {
        PeopleManager.Instance.UpdateRoleDataAfterDialogue();
        UnShowDiaMenu();
        MainMenuManager.Instance.Invoke("ShowMainMenu", 0.5f);
        Invoke("UnShowDialogueBG", 0.5f);
        FungusManager.Instance.GetComponent<AudioSource>().Stop();
        
    }
    public void ExitDialogueShit()
    {
        PeopleManager.Instance.UpdateRoleDataAfterDialogue();
        UnShowDiaMenu();
    }

    public void ChangeRoleSprite()
    {
        GameObject lyric = GameObject.Find("Lyric holder");
        Image image = lyric.GetComponentInChildren<Image>();
        string path = "Role/Lyric_light";
        Sprite sprite = Resources.Load<Sprite>(path);
        Debug.Log(7467);
        image.sprite = sprite;
    }

    protected void UnShowDiaMenu()
    {
        diaMenu.SetActive(false);
    }

    protected void ShowDiaMenu()
    {
        diaMenu.SetActive(true);
    }

    protected void ShowDialogueBG()
    {
        diaBG.SetActive(true);
    }

    protected void UnShowDialogueBG()
    {
        diaBG.SetActive(false);
    }
}
