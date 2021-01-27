using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PrefightSkillDisplay : MonoBehaviour
{
    public GameObject SkillObj1;
    public GameObject SkillObj2;
    public GameObject SkillObj3;
    public GameObject SkillObj4;
    private MonsterInfo monsterInfo;
    void Start()
    {
        monsterInfo = gameObject.GetComponent<MonsterInfo>();
    }
    public void DisplaySkill()
    {
        int arrayCount = 0;
        foreach (SkillsDBStructure skill in monsterInfo.monsterSkill)
        {
            arrayCount++;
            GameObject currentSkillObj = GetCurrentSkillObj(arrayCount);
            currentSkillObj.GetComponent<TextMeshProUGUI>().text =
                skill.skillName.ToUpper() + " - " + skill.skillDescription.ToUpper() + "\n[" +
                skill.dmgType.ToUpper() + "]\n" +
                "DMG: " + skill.DMG + "  MP COST: " + skill.MPCost;
                
        }
    }
    public GameObject GetCurrentSkillObj(int arrayCount)
    {
        if (arrayCount == 1)
        { return SkillObj1; }
        if (arrayCount == 2)
        { return SkillObj2; }
        if (arrayCount == 3)
        { return SkillObj3; }
        if (arrayCount == 4)
        { return SkillObj4; }
        else
        {
            Debug.LogWarning("Error: Get Current Skill Obj taking skill count: " + arrayCount);
            return null;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
