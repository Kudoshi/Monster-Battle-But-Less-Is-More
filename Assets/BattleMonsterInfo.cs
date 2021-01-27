using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterInfo : MonoBehaviour
{
    public int isEnemy;
    //---------- MONSTER INFO--------------------//
    [System.NonSerialized]
    public string monsterName;
    [System.NonSerialized]
    public SkillsDBStructure[] monsterSkill;
    [System.NonSerialized]
    public Sprite monsterIcon;
    [System.NonSerialized]
    public int LVL, HP, MP, ATK, DEF, MATK, MDEF;
    ///////////////////////////////////////////////
    ///           FUNCTIONS                     //

    public void CopyMonsterInfo(MonsterInfo MonsterInfo)
    {
        monsterName = MonsterInfo.monsterName;
        monsterSkill = MonsterInfo.monsterSkill;
        monsterIcon = MonsterInfo.monsterIcon;
        LVL = MonsterInfo.LVL;
        HP = MonsterInfo.HP;
        MP = MonsterInfo.MP;
        ATK = MonsterInfo.ATK;
        DEF = MonsterInfo.DEF;
        MATK = MonsterInfo.MATK;
        MDEF = MonsterInfo.MDEF;
        monsterSkill = (SkillsDBStructure[])MonsterInfo.monsterSkill.Clone();
    }
    public void PrintMonsterStats()
    {
        Debug.Log("---------MONSTER STATS----------");
        Debug.Log(monsterName);
        Debug.Log(LVL);
        Debug.Log(HP);
        Debug.Log(MP);
        Debug.Log(ATK);
        Debug.Log(monsterSkill);
        Debug.Log(monsterIcon);
        Debug.Log("-------------------------------");
    }
    public void PrintSkill()
    {
        Debug.Log("-------------" + monsterName + "--------------");
        foreach (SkillsDBStructure skill in monsterSkill)
        {

            Debug.Log(skill.skillName + "   -   " + skill.skillDescription);
            Debug.Log("[" + skill.dmgType + "]");
            Debug.Log("DMG: " + skill.DMG + "   MP Cost:" + skill.MPCost);
            Debug.Log("_____________________");
        }

    }
}
