using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }
    public int currentLevel;
    private void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;

        // Check the scene name as a conditional.
        switch (buildIndex)
        {
            case 0:
                currentLevel = buildIndex;
                break;
            case 1:
                Debug.LogWarning("Error: GameScene created in wrong level!");
                break;
        }
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }
    public void printCurrentLevel()
    {
        Debug.Log("Current Level: " + currentLevel);
    }
    public void changeCurrentLevel()
    {
        Debug.Log("Entered chg level");
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////  LEVEL MANAGE THROUGH MENU /////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public void setLevel1()
    {
        currentLevel = 1;
        printCurrentLevel();
        changeCurrentLevel();
    }
    public void setLevel2()
    {
        currentLevel = 2;
    }
    public void setLevel3()
    {
        currentLevel = 3;
    }

}
