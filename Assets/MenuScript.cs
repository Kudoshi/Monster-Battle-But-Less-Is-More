using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelsMenu;

    public void play()
    {
        MainMenu.SetActive(false);
        LevelsMenu.SetActive(true);
    }

    public void levelsback()
    {
        MainMenu.SetActive(true);
        LevelsMenu.SetActive(false);
    }
}
