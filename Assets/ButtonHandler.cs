using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private BattleManager battleManager;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = gameObject.GetComponent<BattleManager>(); 
    }
    public void DebugNextTurn()
    {
        battleManager.EndTurn();
    }
    public void Skill1Used()
    {
        battleManager.SkillUsed(1, 0);
    }public void Skill2Used()
    {
        battleManager.SkillUsed(2, 0);
    }public void Skill3Used()
    {
        battleManager.SkillUsed(3, 0);
    }public void Skill4Used()
    {
        battleManager.SkillUsed(4, 0);
    }
}
