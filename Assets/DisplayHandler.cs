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
    public GameObject YMonsterObj;
    public GameObject EMonsterObj;
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

    void Start()
    {

        Invoke("StartingDisplay", 1.9f);
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
    public void DisplayWhoseTurn(int whoseTurn)
    {
        if (whoseTurn == 1)
            WhoseTurn.GetComponent<TextMeshProUGUI>().text = "ENEMY TURN";
        else if (whoseTurn == 2)
            WhoseTurn.GetComponent<TextMeshProUGUI>().text = "YOUR TURN";
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
}
