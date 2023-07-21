using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGuider : MonoBehaviour
{
    ERoles chosenRole;
    public GameObject chooseRoleUI;
    public GameObject confirmChooseUI;
    public Button Role1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* public void ShowChooseRole()
    {
        chooseRoleUI.SetActive(true);
    }*/

    public void ChooseRole(int roleNo)
    {
        chosenRole= (ERoles)roleNo;
        ShowConfirmChoose();
    }

    public void ShowConfirmChoose()
    {
        confirmChooseUI.SetActive(true);
    }

    public void BackChoose()
    {
        confirmChooseUI.SetActive(false);
    }

    public void ConfirmChoose()
    {
        confirmChooseUI.SetActive(false);
        chooseRoleUI.SetActive(false);
    }

    public void EndChoose()
    {
        GameManager.Instance.role = chosenRole;
        SceneManager.LoadScene("Main Menu");
    }
}
