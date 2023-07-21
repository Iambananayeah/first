using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoInstance<RoleManager>
{
    public Role role;

    public override void init()
    {
        base.init();
        role = new Role(ERoles.Lyric);
    }
}
