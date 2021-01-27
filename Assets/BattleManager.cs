using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("Battle Monster")]
    public GameObject YourMonster;
    public GameObject EnemyMonster;
    [Header("Strategy MonsterInfo")]
    public GameObject oldYourMonster;
    public GameObject oldEnemyMonster;
    [Header("Managers")]
    public GameObject DisplayHandlerObj;


    private DamageLogicHandler DMGHandler;
    private DisplayHandler displayHandler;
    private TurnCounterHandler turnCountHandler;
    void Start()
    {
        CopyOldMonsterInfo();
       turnCountHandler = gameObject.GetComponent<TurnCounterHandler>();
        displayHandler = DisplayHandlerObj.GetComponent<DisplayHandler>();
        DMGHandler = gameObject.GetComponent<DamageLogicHandler>();
    }

    private void CopyOldMonsterInfo()
    {
        //Your Monster
        MonsterInfo oldYourMonsterInfo = oldYourMonster.GetComponent<MonsterInfo>();
        YourMonster.GetComponent<BattleMonsterInfo>().CopyMonsterInfo(oldYourMonsterInfo);

        //Enemy Monster

        MonsterInfo oldEnemyMonsterInfo = oldEnemyMonster.GetComponent<MonsterInfo>();
        EnemyMonster.GetComponent<BattleMonsterInfo>().CopyMonsterInfo(oldEnemyMonsterInfo);
    }

    public void ChangeTurnDisplay(int turn, int isYourTurn)
    {
        displayHandler.DisplayWhoseTurn(isYourTurn);
        displayHandler.DisplayTurnCounter(turn);
    }
    public void EndTurn()
    {
        turnCountHandler.EndTurn();
    }
    public void SkillUsed(int WhatSkill, int casterIsEnemy)
    {
        int damagedealt = DMGHandler.StartDamageCalculation(WhatSkill, casterIsEnemy);
        int victim;
        if (casterIsEnemy == 0)
        {
            victim = 2;
            displayHandler.DisplayDamageCounter(victim, damagedealt);
        }
        else if (casterIsEnemy == 1)
        {
            victim = 1;
            displayHandler.DisplayDamageCounter(victim, damagedealt);
        }
        EndTurn();
    }
}
    