using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusManager : MonoInstance<CircusManager>
{
    // Start is called before the first frame update
    public Circus circus;
    public Flowchart flowchart;

    public override void init()
    {
        base.init();
        circus = new Circus(flowchart);

    }

}
