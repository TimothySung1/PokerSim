using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;

    public void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        TitleScreen,
        PokerTable
    }

    public void Switch(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void SwitchToTitle()
    {
        SceneManager.LoadScene(Scene.TitleScreen.ToString());
    }

    public void SwitchToTable()
    {
        SceneManager.LoadScene(Scene.PokerTable.ToString());
    }
}
