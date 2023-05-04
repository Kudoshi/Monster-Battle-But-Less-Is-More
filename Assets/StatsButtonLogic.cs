using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsButtonLogic : MonoBehaviour
{
    public GameObject YourMonster;
    public GameObject PhaseController;
    private StatsDisplayLogic Display;
    private MonsterInfo monsterInfo;
    private PhaseController phaseController;

    void Start()
    {
        Display = YourMonster.GetComponent<StatsDisplayLogic>();
        monsterInfo = YourMonster.GetComponent<MonsterInfo>();
        phaseController = PhaseController.GetComponent<PhaseController>();
    }
    private void RefreshDisplay()
    {
        Display.RefreshDisplayStats();
    }
    public void HPadd()
    {
        monsterInfo.HP++;
        RefreshDisplay();
    }
    public void HPminus()
    {
        monsterInfo.HP--;
            RefreshDisplay();
    }
    public void MPadd()
    {
        monsterInfo.MP++;
        RefreshDisplay();
    }

    public void MPminus()
    {
        monsterInfo.MP--;
        RefreshDisplay();
    }
    public void DEFadd()
    {
        monsterInfo.DEF++;
        RefreshDisplay();
    }
    public void DEFminus()
    {
        monsterInfo.DEF--;
        RefreshDisplay();
    }
    public void ATKadd()
    {
        monsterInfo.ATK++;
        RefreshDisplay();
    }
    public void ATKminus()
    {
        monsterInfo.ATK--;
        RefreshDisplay();
    }
    public void MATKadd()
    {
        monsterInfo.MATK++;
        RefreshDisplay();
    }
    public void MATKminus()
    {
        monsterInfo.MATK--;
        RefreshDisplay();
    }
    public void MDEFadd()
    {
        monsterInfo.MDEF++;
        RefreshDisplay();
    }
    public void MDEFminus()
    {
        monsterInfo.MDEF--;
        RefreshDisplay();
    }


    public void StartBattle()
    {
        phaseController.PhaseToFight();
    }
    }
