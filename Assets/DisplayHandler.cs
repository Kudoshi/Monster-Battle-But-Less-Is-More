using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHandler : MonoBehaviour
{
    [Header("General Display")]
    public GameObject TurnCounter;
    public GameObject MiddleDisplay;
    public GameObject WhoseTurn;

    [Header("Monster Icon Display")]
    public GameObject LeftMonsterIcon;
    public GameObject RightMonsterIcon;
    public GameObject LeftDmgDisplay;
    public GameObject RightDmgDisplay;
    [Header("Your Monster Info")]
    public GameObject YMonsterObj; //Monster info
    public GameObject EMonsterObj; //Monster info
    private BattleMonsterInfo YMonsterInfo;
    private BattleMonsterInfo EMonsterInfo;
    public GameObject YMonName;
    public GameObject YMonLevel;
    public GameObject YMonHP;
    public GameObject YMonMP;
    [Header("Enemy Monster Info")]
    public GameObject EMonName;
    public GameObject EMonLevel;
    public GameObject EMonHP;
    public GameObject EMonMP;
    [Header("Skills")]
    public GameObject SkillName1;
    public GameObject SkillDescription1;
    public GameObject SkillName2;
    public GameObject SkillDescription2;
    public GameObject SkillName3;
    public GameObject SkillDescription3;
    public GameObject SkillName4;
    public GameObject SkillDescription4;
    [Header("Skill Button")]
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;

    void Start()
    {

        Invoke("StartingDisplay", 1.5f);
    }

    private void StartingDisplay()
    {
        YMonsterInfo = YMonsterObj.GetComponent<BattleMonsterInfo>();
        EMonsterInfo = EMonsterObj.GetComponent<BattleMonsterInfo>();
        SetYMonsterInfo();
        SetEMonsterInfo();
        SetGeneralInfo();
        SetSkillInfo();
    }
    public void SetSkillInfo()
    {
        int arrayCount = 0;
        foreach (SkillsDBStructure skill in YMonsterInfo.monsterSkill)
        {
            arrayCount++;
            GameObject SkillTitle = GetCurrentSkillObj(arrayCount);
            GameObject SkillDesc = GetCurrentSkillDesc(arrayCount);
            SkillTitle.GetComponent<TextMeshProUGUI>().text = skill.skillName.ToUpper();
            SkillDesc.GetComponent<TextMeshProUGUI>().text =
            skill.skillDescription.ToUpper() + "\n[" + skill.dmgType.ToUpper() + "]\n" +
            "DMG: " + skill.DMG + "  MP: " + skill.MPCost;
        }
    }
    public GameObject GetCurrentSkillObj(int arrayCount)
    {
        if (arrayCount == 1)
        { return SkillName1; }
        if (arrayCount == 2)
        { return SkillName2; }
        if (arrayCount == 3)
        { return SkillName3; }
        if (arrayCount == 4)
        { return SkillName4; }
        else
        {
            Debug.LogWarning("Error: Get Current Skill Obj taking skill count: " + arrayCount);
            return null;
        }

    }public GameObject GetCurrentSkillDesc(int arrayCount)
    {
        if (arrayCount == 1)
        { return SkillDescription1; }
        if (arrayCount == 2)
        { return SkillDescription2; }
        if (arrayCount == 3)
        { return SkillDescription3; }
        if (arrayCount == 4)
        { return SkillDescription4; }
        else
        {
            Debug.LogWarning("Error: Get Current Skill Obj taking skill count: " + arrayCount);
            return null;
        }

    }
    public void SetGeneralInfo()
    {
        TurnCounter.GetComponent<TextMeshProUGUI>().text = "TURN 1";
        WhoseTurn.GetComponent<TextMeshProUGUI>().text = "YOUR TURN";
    }
    public void SetYMonsterInfo()
    {
        
        LeftMonsterIcon.GetComponent<Image>().sprite = YMonsterInfo.monsterIcon;
        YMonName.GetComponent<TextMeshProUGUI>().text = YMonsterInfo.monsterName;
        YMonLevel.GetComponent<TextMeshProUGUI>().text = "LVL" + YMonsterInfo.LVL.ToString();
        RefreshYMonInfo();
        
    }
    public void SetEMonsterInfo()
    {
        RightMonsterIcon.GetComponent<Image>().sprite = EMonsterInfo.monsterIcon;
        EMonName.GetComponent<TextMeshProUGUI>().text = EMonsterInfo.monsterName;
        EMonLevel.GetComponent<TextMeshProUGUI>().text = "LVL " + EMonsterInfo.LVL.ToString();
        RefreshEMonInfo();
    }
    public void DisplayTurnCounter(int turn)
    {
        TurnCounter.GetComponent<TextMeshProUGUI>().text = "TURN " + turn.ToString();
    }
    public void DisplayWriteInMiddle(string message)
    {
        MiddleDisplay.GetComponent<TextMeshProUGUI>().text = message.ToString();
    }
    private void EnableSkillMenu()
    {
        Button1.GetComponent<Button>().interactable = true;
        Button2.GetComponent<Button>().interactable = true;
        Button3.GetComponent<Button>().interactable = true;
        Button4.GetComponent<Button>().interactable = true;
    }
    private void DisableSkillMenu()
    {
        Button1.GetComponent<Button>().interactable = false;
        Button2.GetComponent<Button>().interactable = false;
        Button3.GetComponent<Button>().interactable = false;
        Button4.GetComponent<Button>().interactable = false;

    }
    public void DisplayWhoseTurn(int isYourTurn)
    {
        if (isYourTurn == 0)
        {
            WhoseTurn.GetComponent<TextMeshProUGUI>().text = "ENEMY TURN";
            DisableSkillMenu();
            Debug.Log("AI's turn now");
        }
        else if (isYourTurn == 1)
        { 
            WhoseTurn.GetComponent<TextMeshProUGUI>().text = "YOUR TURN";
            EnableSkillMenu();
        }
        else
            Debug.LogWarning("whose Turn is not specified correctly");
    }
    public void RefreshYMonInfo()
    {
        YMonHP.GetComponent<TextMeshProUGUI>().text = YMonsterInfo.HP.ToString();
        YMonMP.GetComponent<TextMeshProUGUI>().text = YMonsterInfo.MP.ToString();
    }
    public void RefreshEMonInfo()
    {
        EMonHP.GetComponent<TextMeshProUGUI>().text = EMonsterInfo.HP.ToString();
        EMonMP.GetComponent<TextMeshProUGUI>().text = EMonsterInfo.MP.ToString();
    }
    private void RefreshBothMonInfo()
    {
        RefreshEMonInfo();
        RefreshYMonInfo();
    }
    private void DisableBothDMGDisplay()
    {
        LeftDmgDisplay.SetActive(false);
        RightDmgDisplay.SetActive(false);   
    }
    public void DisplayDamageCounter(int victim, int dmgdealt) //1-YourMonster 2-EnemyMonster
    {
        if (victim == 1)
        {
            LeftDmgDisplay.GetComponent<TextMeshProUGUI>().text = "-" + dmgdealt;
            LeftDmgDisplay.SetActive(true);
        }
        else if (victim == 2)
        {
            RightDmgDisplay.GetComponent<TextMeshProUGUI>().text = "-" + dmgdealt;
            RightDmgDisplay.SetActive(true);
        }
        else
            Debug.LogWarning("Victim: " + victim + " not found!");
        Invoke("DisableBothDMGDisplay", 2.5f);
        RefreshBothMonInfo();
    }
}
