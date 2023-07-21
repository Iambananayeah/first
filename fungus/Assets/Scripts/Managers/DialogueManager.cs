using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Debug.Log(666);
        MainMenuManager.Instance.UnShowMainMenu();
        Invoke("ShowDialogueBG", 0.5f);

    }

    public void ExitDialogue()
    {
        UnShowDiaMenu();
        MainMenuManager.Instance.Invoke("ShowMainMenu", 0.5f);
        Invoke("UnShowDialogueBG", 0.5f);
        FungusManager.Instance.GetComponent<AudioSource>().Stop();
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
