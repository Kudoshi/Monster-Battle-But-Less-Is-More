using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MonsterInfo : MonoBehaviour
{
    [System.NonSerialized]
    public string monsterName;
    [System.NonSerialized]
    public string[] monsterSkill;
    [System.NonSerialized]
    public Sprite monsterIcon;
    [System.NonSerialized]
    public int LVL, HP, MP, ATK, DEF, MATK, MDEF;
    private int oHP, oMP, oATK, oDEF,oMATK, oMDEF;
    




    private float multiplier = 1.00f;
    private float statsMultiplierValue = 0.00f;
    private float MultiplierForEachLevel = 0.03f;
    
    public void CalculateStatsAfterLevel()
    {
        
        if(LVL > 1)
        {
            int diffInLevel = LVL - 1;
            float statsMultiplier = 1 + (diffInLevel * MultiplierForEachLevel);
            HP = (int)Math.Round(HP * statsMultiplier);
            MP = (int)Math.Round(MP * statsMultiplier);
            ATK = (int)Math.Round(ATK * statsMultiplier);
            DEF = (int)Math.Round(DEF * statsMultiplier);
            MATK = (int)Math.Round(MATK * statsMultiplier);
            MDEF = (int)Math.Round(MDEF * statsMultiplier);
        }
        SaveBeginningStats();
    }
    public void AttributeValidation()
    {
        if (HP < 0)
            HP = 0;
        if (MP < 0)
            MP = 0;
        if (ATK < 0)
            ATK = 0;
        if (DEF < 0)
            DEF = 0;
        if (MATK < 0)
            MATK = 0;
        if (MDEF < 0)
            MDEF = 0;
    }
    public float GetMultiplierIncrease()
    {
        statsMultiplierValue += oHP - HP;
        statsMultiplierValue += oMP - MP;
        statsMultiplierValue += oATK - ATK;
        statsMultiplierValue += oDEF - DEF;
         statsMultiplierValue += oMATK - MATK;
         statsMultiplierValue += oMDEF - MDEF;
        multiplier = 1.00f + (statsMultiplierValue * 0.01f);
        statsMultiplierValue = 0.00f;
         return multiplier;
    }
    public float GetMultiplier()
    {
        return multiplier;
    }
    public void SaveBeginningStats()
    {
        
        oHP = HP;
        oMP = MP;
        oATK = ATK;
        oDEF = DEF;
        oMDEF = MDEF;
        oMATK = MATK;
    }
    
   
    public void PrintMonsterStats()
    {
        Debug.Log(monsterName);
        Debug.Log(LVL);
        Debug.Log(HP);
        Debug.Log(MP);
        Debug.Log(ATK);
        Debug.Log(monsterSkill);
        Debug.Log(monsterIcon);
       
    }

}
