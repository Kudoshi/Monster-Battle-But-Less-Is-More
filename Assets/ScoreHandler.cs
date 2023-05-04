using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public GameObject MonsterInfo;
    [System.NonSerialized]
    public float Multiplier;
    [System.NonSerialized]
    public int Score;
    void Start()
    {
        GetMultiplierFromMonsterInfo();
    }
    private void GetMultiplierFromMonsterInfo()
    {
       Multiplier = MonsterInfo.GetComponent<MonsterInfo>().GetMultiplier();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
