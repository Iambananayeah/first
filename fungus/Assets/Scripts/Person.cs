using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ERoles
{
    Lyric=1,
}

public class Person 
{
    public ERoles roleType;
    public string roleName;
    //public bool hasChat;

    private int san;
    private int skill;
    private int suki;

    private Flowchart flowchart;

    public int San
    {
        set 
        {
            if(flowchart)
                flowchart.SetIntegerVariable("san",value);

            san = value;
        }
        get
        {
            return san;
        }
    }
    public int Skill
    {
        set
        {
            if (flowchart)
                flowchart.SetIntegerVariable("skill", value);

            skill= value;
        }
        get
        {
            return skill;
        }
    }
    public int Suki
    {
        set
        {
            if (flowchart)
                flowchart.SetIntegerVariable("suki", value);

            suki = value;
        }
        get
        {
            return suki;
        }
    }

    public Person(ERoles role,Flowchart flowChart)
    {
        this.flowchart = flowChart;
        roleType = role;
       // hasChat = true;
        San = 50;
        Skill = 10;
        Suki = 30;
    }
}
