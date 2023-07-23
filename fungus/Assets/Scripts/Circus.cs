using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Circus 
{
    private int money;
    private int popular;
    private Flowchart flowchart;
    private int actPoints;
    public int ActPoints
    {
        set
        {
            if (flowchart)
                flowchart.SetIntegerVariable("actPoints", value);

            actPoints = value;
        }
        get
        {
            return actPoints;
        }
    }
    public int Money
    {
        set
        {
            if (flowchart)
                flowchart.SetIntegerVariable("money", value);

            money= value;
        }
        get
        {
            return money;
        }
    }
    public int Popular
    {
        set
        {
            if (flowchart)
                flowchart.SetIntegerVariable("popular", value);

            popular = value;
        }
        get
        {
            return popular;
        }
    }

    public Circus (Flowchart flowchart)
    {
        this.flowchart = flowchart;
        Money = 1000;
        Popular = 10;
        ActPoints = 3;
    }
}
