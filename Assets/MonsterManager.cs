﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private GameObject database;
    private LevelDB leveldb;
    private MonsterDB monsterdb;
    private MonsterDBStructure monsterInfo;
    private SkillsDB skilldb;

    //Level info
    private int currentLevel;
    private string yourMonsterName;
    private int yourMonsterLevel;
    private string enemyMonsterName;
    private int enemyMonsterLevel;
    //Monster info
    public GameObject YourMonster;
    public GameObject EnemyMonster;
    private MonsterInfo yourMonsterInfo;
    private MonsterInfo enemyMonsterInfo;

   
    void Start()
    {
        database = GameObject.Find("Database");
        //currentLevel =  LevelManager.Instance.getCurrentLevel();
        currentLevel = 1; //dontforget to delete this
        leveldb = database.GetComponent<LevelDB>();
        monsterdb = database.GetComponent<MonsterDB>();
        skilldb = database.GetComponent<SkillsDB>();

        yourMonsterInfo = YourMonster.GetComponent<MonsterInfo>();
        enemyMonsterInfo = EnemyMonster.GetComponent<MonsterInfo>();


        AssignLevelInfo();
        AssignYourMonster();
        AssignEnemyMonster();
    }
    public void AssignLevelInfo()
    {
        LevelDBStructure level = Array.Find(leveldb.LevelList, element => element.Level == currentLevel);
        if (level == null)
        {
            Debug.LogWarning("Level: " + currentLevel + " not found!");
            return;
        }
        yourMonsterLevel = level.yourMonsterLevel;
        yourMonsterName = level.yourMonsterName;
        enemyMonsterName = level.enemyMonsterName;
        enemyMonsterLevel = level.enemyMonsterLevel;
    }

    public void AssignYourMonster()
    {
        MonsterDBStructure monster = Array.Find(monsterdb.MonsterList, element => element.monsterName == yourMonsterName);
        if (monster == null)
        {
            Debug.LogWarning("Monster: " + yourMonsterName + " not found in monster DB");
            return;
        }

        //Copy monster's stats from db to monsterinfo
        yourMonsterInfo.monsterName = monster.monsterName;
        yourMonsterInfo.LVL = yourMonsterLevel;
        yourMonsterInfo.HP = monster.HP;
        yourMonsterInfo.MP = monster.MP;
        yourMonsterInfo.ATK = monster.ATK;
        yourMonsterInfo.DEF = monster.DEF;
        yourMonsterInfo.MATK = monster.MATK;
        yourMonsterInfo.MDEF = monster.MDEF;
        yourMonsterInfo.monsterIcon = monster.monsterIcon;

        AssignSkillOnMonster(yourMonsterInfo, monster.monsterSkill); //Passes on the array of skills
        yourMonsterInfo.CalculateStatsAfterLevel();
    }

    public void AssignSkillOnMonster(MonsterInfo skillOwner, SkillsDBStructure[] listOfSkill)
    {
        foreach(SkillsDBStructure skill in listOfSkill)
        {
            //Find in the skill list, whereby skill name currently iterated is = skill name in DB
            SkillsDBStructure skillInfoDB = Array.Find(skilldb.SkillList, element => element.skillName == skill.skillName);
            skill.skillDescription = skillInfoDB.skillDescription;
            skill.skillVariable = skillInfoDB.skillVariable;
        }
    }
    public void AssignEnemyMonster()
    {
        MonsterDBStructure monster = Array.Find(monsterdb.MonsterList, element => element.monsterName == enemyMonsterName);
        if (monster == null)
        {
            Debug.LogWarning("Monster: " + enemyMonsterName + " not found in monster DB");
            return;
        }
        
        //Copy monster's stats from db to monsterinfo
        enemyMonsterInfo.monsterName = monster.monsterName;
        enemyMonsterInfo.LVL = enemyMonsterLevel;
        enemyMonsterInfo.HP = monster.HP;
        enemyMonsterInfo.MP = monster.MP;
        enemyMonsterInfo.ATK = monster.ATK;
        enemyMonsterInfo.DEF = monster.DEF;
        enemyMonsterInfo.MATK = monster.MATK;
        enemyMonsterInfo.MDEF = monster.MDEF;
        enemyMonsterInfo.monsterIcon = monster.monsterIcon;

        AssignSkillOnMonster(enemyMonsterInfo, monster.monsterSkill); //Passes on the array of skills
        enemyMonsterInfo.CalculateStatsAfterLevel();
    }
}