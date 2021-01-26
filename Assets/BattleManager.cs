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
    void Start()
    {
        CopyOldMonsterInfo();
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
}
