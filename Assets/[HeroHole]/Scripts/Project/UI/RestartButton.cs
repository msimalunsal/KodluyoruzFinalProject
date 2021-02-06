using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();

        //onClick.AddListener(() => GameManager.Instance.EndGame());
        onClick.AddListener(RestartLevel);
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        //onClick.RemoveListener(() => GameManager.Instance.EndGame());
        onClick.RemoveListener(RestartLevel);
    }

    void RestartLevel()
    {
        //GameManager.Instance.EndGame();

        //LevelManager.Instance.StartLevel();
        //for (int i = 0; i < SceneManager.sceneCount; i++)
        //{
        //    if (SceneManager.GetSceneAt(i).name.Contains("Level"))
        //    {
        //        SceneManager.UnloadScene(SceneManager.GetSceneAt(i).name);
        //    }
        //}
        LevelManager.Instance.LoadCurrentScene();
        GameManager.Instance.StartGame();
        LevelManager.Instance.StartLevel();
    }
}
