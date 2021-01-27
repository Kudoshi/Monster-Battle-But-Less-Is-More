using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageLogicHandler : MonoBehaviour
{
    public GameObject YourMonsterObj;
    public GameObject EnemyMonsterObj;

    // DAMAGE VARIABLE
    private float attackMultiplier = 50; //The lesser the number, the more ATK adds to the dmg
  //  private float blockMultiplier = 100; //The lesser the number, the more DEF can block dmg
    private float maxPercentBlock = 0.75f;

    private BattleMonsterInfo YMon;
    private BattleMonsterInfo EMon;
    void Start()
    {
        YMon = YourMonsterObj.GetComponent<BattleMonsterInfo>();
        EMon = EnemyMonsterObj.GetComponent<BattleMonsterInfo>();
    }

    public int StartDamageCalculation(int WhatSkill, int casterIsEnemy)
    {
        BattleMonsterInfo caster = GetCasterId(casterIsEnemy);
        BattleMonsterInfo victim = GetVictimId(casterIsEnemy);

        string usedSkillName = caster.monsterSkill[WhatSkill - 1].skillName;
        SkillsDBStructure usedSkillInfo = Array.Find(YMon.monsterSkill, element => element.skillName == usedSkillName);

       int damagedealt = CalculateDamage(caster,victim , usedSkillInfo);
        return damagedealt;
    }
    private int CalculateDamage(BattleMonsterInfo casterInfo, BattleMonsterInfo victimInfo, SkillsDBStructure skillUsed)
    {
        float finaldmg = 0;
        //Check Type of Damage
        if (skillUsed.dmgType == "Physical Attack")
        {
            //Caster Process
            float dmg = (float)skillUsed.DMG;
            float atk = (float)casterInfo.ATK;
            float casterDMG = dmg * ((atk / attackMultiplier) + 1.00f);



            //Victim Process
            float victimDEF = (float)victimInfo.DEF;
            float casterATK = (float)casterInfo.ATK;
            float percentblockedDamage = (maxPercentBlock * (victimDEF / casterATK));
            if (percentblockedDamage > maxPercentBlock) //Make sure it does not exceed 0.75f
                percentblockedDamage = maxPercentBlock;
            finaldmg = casterDMG * (1.0f - percentblockedDamage);

            //Minus MP of caster
            casterInfo.MP -= skillUsed.MPCost;

            //Minus HP of victim
            int finaldmgafteroundup = (int)(finaldmg + 0.5f);  //Plus 0.5f for rounding purposes
            victimInfo.HP -= finaldmgafteroundup;

            if (victimInfo.HP <= 0)
            {
                victimInfo.HP = 0;
            }
            return finaldmgafteroundup;
        }
        else if (skillUsed.dmgType == "Magical Attack")
        {
            //Caster Process
            float dmg = (float)skillUsed.DMG;
            float atk = (float)casterInfo.MATK;
            float casterDMG = dmg * ((atk / attackMultiplier) + 1.00f);

            //Victim Process
            float victimMDEF = (float)victimInfo.MDEF;
            float casterMATK = (float)casterInfo.MATK;
            float percentblockedDamage = (maxPercentBlock * (victimMDEF / casterMATK));
            if (percentblockedDamage > maxPercentBlock) //Make sure it does not exceed 0.75f
                percentblockedDamage = maxPercentBlock;
            finaldmg = casterDMG * (1.0f - percentblockedDamage);

            //Minus MP of caster
            casterInfo.MP -= skillUsed.MPCost;

            //Minus HP of victim
            int finaldmgafteroundup = (int)(finaldmg + 0.5f);  //Plus 0.5f for rounding purposes
            victimInfo.HP -= finaldmgafteroundup;
            if (victimInfo.HP <= 0)
            {
                victimInfo.HP = 0;
            }
            return finaldmgafteroundup;
        }
        else
        {
            Debug.LogWarning("Dmg type of skill : "+skillUsed.skillName+ " is not correct");
            return 0;
        }
    }
    private BattleMonsterInfo GetCasterId(int casterIsEnemy)
    {
        if (casterIsEnemy == 0)
            return YMon;
        else if (casterIsEnemy == 1)
            return EMon;
        else
        {
            Debug.LogWarning("casterIsEnemy is not specified correctly : " + casterIsEnemy);
            return null;
        }
        
    
     }
    public BattleMonsterInfo GetVictimId(int casterIsEnemy)
    {
        if (casterIsEnemy == 0)
            return EMon;
        else if (casterIsEnemy == 1)
            return YMon;
        else
        {
            Debug.LogWarning("casterIsEnemy is not specified correctly : " + casterIsEnemy);
            return null;
        }
        
    }
}
