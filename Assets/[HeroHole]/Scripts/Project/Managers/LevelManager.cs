using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData LevelData;
    
    #region Properties
    private bool isLevelStarted;
    public bool IsLevelStarted { get { return isLevelStarted; } set { isLevelStarted = value; } }

    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }

    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("LastLevel", 0);
        }
        set
        {
            if (value >= LevelData.Levels.Count)
                value = 0;

            PlayerPrefs.SetInt("LastLevel", value);
        }
    }

    #endregion
    private void OnEnable()
    {
        EventManager.OnSceneLoaded.AddListener(() => isLevelStarted = false);
    }
    private void OnDisable()
    {
        EventManager.OnSceneLoaded.RemoveListener(() => isLevelStarted = false);

    }
    #region Public Methods

    public void StartLevel()
    {
        if (IsLevelStarted)
            return;

        IsLevelStarted = true;
        GameData.IsCanMove = true;

        EventManager.OnLevelStart.Invoke();
    }

    public void FinishLevel()
    {
        if (!IsLevelStarted)
            return;

        IsLevelStarted = false;
        GameData.IsCanMove = false;

        EventManager.OnLevelFinish.Invoke();
        Debug.Log("Level finish");
    }

    public void FailLevel()
    {
        if (!IsLevelStarted)
            return;

        IsLevelStarted = false;
        EventManager.OnLevelFail.Invoke();
        Debug.Log("Level fail");
    }

    public void LoadCurrentScene()
    {
        StartCoroutine(LoadCurrentSceneCo());
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadNextSceneCo());
        EventManager.OnLevelChange.Invoke();
    }

    IEnumerator LoadCurrentSceneCo()
    {
        
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(SceneManager.GetSceneByBuildIndex(buildIndex).name);
        //Get how many scenes are loaded.
        int sceneCount = SceneManager.sceneCount;

        //Create list for scenes to be unloaded.
        List<Scene> scenesToBeUnloaded = new List<Scene>();

        //Add scenes to be unloaded to the list.
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i); //Sadece yuklenen sahneleri verir, build'kileri degil
            if (scene.name.Contains("Level"))
            {
                scenesToBeUnloaded.Add(scene);
            }
        }

        //Unload all scenes that needs to be unloaded.
        foreach (var s in scenesToBeUnloaded)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(s.buildIndex).name);
            yield return SceneManager.UnloadSceneAsync(s.buildIndex);
        }

        //Check if we can load this scene
        if (!Application.CanStreamedLevelBeLoaded(buildIndex))
        {
            //Set it back to default
            buildIndex = 2;
        }

        //Load the scene
        yield return SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        Debug.Log(SceneManager.GetSceneByBuildIndex(buildIndex).name);

        Scene levelScene = SceneManager.GetSceneByBuildIndex(buildIndex);
        SceneManager.SetActiveScene(levelScene);
        PlayerPrefs.SetString("LastLevel", levelScene.name);
        EventManager.OnSceneLoaded.Invoke();
    }

    IEnumerator LoadNextSceneCo()
    {
        //Cach next level build index.
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;

        //Get how many scenes are loaded.
        int sceneCount = SceneManager.sceneCount;

        //Create list for scenes to be unloaded.
        List<Scene> scenesToBeUnloaded = new List<Scene>();

        //Add scenes to be unloaded to the list.
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i); //Sadece yuklenen sahneleri verir, build'kileri degil
            if (scene.name.Contains("Level"))
            {
                scenesToBeUnloaded.Add(scene);
            }
        }

        //Unload all scenes that needs to be unloaded.
        foreach (var s in scenesToBeUnloaded)
        {
            yield return SceneManager.UnloadSceneAsync(s.buildIndex);
        }

        //Check if we can load this scene
        if (!Application.CanStreamedLevelBeLoaded(buildIndex))
        {
            //Set it back to default
            buildIndex = 2;
        }

        //Load the scene
        yield return SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        Scene levelScene = SceneManager.GetSceneByBuildIndex(buildIndex);
        SceneManager.SetActiveScene(levelScene);
        PlayerPrefs.SetString("LastLevel", levelScene.name);
        EventManager.OnSceneLoaded.Invoke();

    }
    #endregion

}
