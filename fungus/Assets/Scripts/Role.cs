using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ERoles
{
    Lyric=1,
}

public class Role 
{
    public ERoles roleType;
    public string roleName;
    public bool hasChat;

    private int san;
    private int skill;
    private int suki;

    public int San { get => san; set => san = value; }
    public int Skill { get => skill; set => skill = value; }
    public int Suki { get => suki; set => suki = value; }

    public Role(ERoles role)
    {
        roleType = role;
        hasChat = true;
        san = 50;
        skill = 10;
        suki = 30;
    }
}
