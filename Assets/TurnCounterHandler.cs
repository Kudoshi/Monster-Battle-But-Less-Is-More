using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounterHandler : MonoBehaviour
{
    [System.NonSerialized]
    public int TurnCount, isYourTurn;
    private BattleManager battleManager;
    void Start()
    {
        TurnCount = 1;
        isYourTurn = 1;
        battleManager = gameObject.GetComponent<BattleManager>();
    }
    public void EndTurn()
    {
        
        ChangeWhoseTurn();
    }
    private void ChangeWhoseTurn()//Reverses the turn
    {
        if (isYourTurn == 1) //check previous turn is whose
        {
            isYourTurn = 0;

            
        }
        else if (isYourTurn == 0)
        {
            isYourTurn = 1;
            TurnCount++;
        }
        battleManager.ChangeTurnDisplay(TurnCount, isYourTurn);
    }
}
