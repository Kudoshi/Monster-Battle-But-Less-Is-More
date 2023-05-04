using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterDBStructure
{
    public string monsterName;
    public SkillsDBStructure[] monsterSkill;
    public Sprite monsterIcon;

    public int HP;
    public int MP;
    public int ATK;
    public int DEF;
    public int MATK;
    public int MDEF;
}
