using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatsDisplayLogic : MonoBehaviour
{

    private MonsterInfo monsterInfo;

    public int isEnemy;
    public GameObject ScriptOwner;
    public GameObject MultiplierObj;
    public GameObject LevelText;
    [Header("MONSTER INFO")]
    public GameObject monsterName;
    public GameObject monsterLevel;
    public GameObject monsterIcon;
    [Header("STATS")]
    public GameObject HP;
    public GameObject MP;
    public GameObject ATK;
    public GameObject DEF;
    public GameObject MATK;
    public GameObject MDEF;
    /*[Header("SKILLS")]
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;*/

    
    private void Start()
    {
        monsterInfo = ScriptOwner.GetComponent<MonsterInfo>();
        Invoke("RefreshDisplayStats", 1.2f);
        SetLevel();
    }
    public void SetLevel()
    {
        if (isEnemy == 0)
        {
            int currentLevel = 1; //Dontforget to delete it later
            //int currentLevel = LevelManager.Instance.getCurrentLevel();
            LevelText.GetComponent<TextMeshProUGUI>().text = currentLevel.ToString();
        }
       
    }
    public void RefreshDisplayStats()
    {
        if (isEnemy == 0)
        {
            monsterInfo.AttributeValidation();
            //MONSTER INFO
            monsterName.GetComponent<TextMeshProUGUI>().text = monsterInfo.monsterName;

            monsterLevel.GetComponent<TextMeshProUGUI>().text = "LVL " + monsterInfo.LVL.ToString();
            monsterIcon.GetComponent<Image>().sprite = monsterInfo.monsterIcon;
            //STATS
            HP.GetComponent<TMP_InputField>().text = monsterInfo.HP.ToString();
            MP.GetComponent<TMP_InputField>().text = monsterInfo.MP.ToString();
            ATK.GetComponent<TMP_InputField>().text = monsterInfo.ATK.ToString();
            DEF.GetComponent<TMP_InputField>().text = monsterInfo.DEF.ToString();
            MATK.GetComponent<TMP_InputField>().text = monsterInfo.MATK.ToString();
            MDEF.GetComponent<TMP_InputField>().text = monsterInfo.MDEF.ToString();

           
            MultiplierObj.GetComponent<TextMeshProUGUI>().text = "x " + monsterInfo.GetMultiplierIncrease().ToString();
        }
        else
        {
            //MONSTER INFO
            monsterName.GetComponent<TextMeshProUGUI>().text = monsterInfo.monsterName;
           
            monsterLevel.GetComponent<TextMeshProUGUI>().text = "LVL " + monsterInfo.LVL.ToString();
            monsterIcon.GetComponent<Image>().sprite = monsterInfo.monsterIcon;
            //STATS
            HP.GetComponent<TextMeshProUGUI>().text = monsterInfo.HP.ToString();
            MP.GetComponent<TextMeshProUGUI>().text = monsterInfo.MP.ToString();
            ATK.GetComponent<TextMeshProUGUI>().text = monsterInfo.ATK.ToString();
            DEF.GetComponent<TextMeshProUGUI>().text = monsterInfo.DEF.ToString();
            MATK.GetComponent<TextMeshProUGUI>().text = monsterInfo.MATK.ToString();
            MDEF.GetComponent<TextMeshProUGUI>().text = monsterInfo.MDEF.ToString();
        }
 

    }
}
