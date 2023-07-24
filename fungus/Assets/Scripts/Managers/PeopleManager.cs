using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PeopleManager : MonoInstance<PeopleManager>
{
    public Person role;
    public Flowchart flowchart;

    public override void init()
    {
        base.init();
        role = new Person(ERoles.Lyric,flowchart);
       
    }

    public void UpdateRoleDataAfterDialogue()
    {
        role.San = flowchart.GetIntegerVariable("san");
        role.Skill = flowchart.GetIntegerVariable("skill");
        role.Suki = flowchart.GetIntegerVariable("suki");

        Circus circus = CircusManager.Instance.circus;
        circus.Money = flowchart.GetIntegerVariable("money");
        circus.Popular = flowchart.GetIntegerVariable("popular");
        circus.ActPoints = flowchart.GetIntegerVariable("actPoints");
    }


}
