using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject PreFight;
    public GameObject StrategyPhase;
    public GameObject BattleCanvas;
    [Header("Components")]
    public GameObject FightPhase;
    public GameObject BattleManager;

    void Start()
    {
        PreFight.SetActive(true);
        StrategyPhase.SetActive(true);
        Debug.Log("--------------STRATEGY PHASE----------------");

        FightPhase.SetActive(false);
        BattleCanvas.SetActive(false);
        Invoke("DisableStrategyPhaseTitle", 2.5f);
    }
    private void DisableStrategyPhaseTitle()
    {
        StrategyPhase.SetActive(false);
    }
    private void DisableFightPhaseTitle()
    {
        FightPhase.SetActive(false);
        PreFight.SetActive(false);
    }

    public void PhaseToFight()
    {
        Debug.Log("--------------BATTLE PHASE----------------");
        FightPhase.SetActive(true);
        BattleManager.SetActive(true);
        BattleCanvas.SetActive(true);
        Invoke("DisableFightPhaseTitle", 2.5f);
        
    }
}
