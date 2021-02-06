using UnityEngine;
using UnityEngine.UI;

public class StartLevelPanel : Panel
{
    public Text tutorialText;
    #region Private Methods
    void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        HidePanel();
        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnSceneLoaded.AddListener(ShowPanel);
        EventManager.OnLevelStart.AddListener(HidePanel);
        EventManager.OnGameStart.AddListener(() => this.Wait(3f, getTutorial));
    }

    void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(ShowPanel);
        EventManager.OnSceneLoaded.RemoveListener(ShowPanel);
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        EventManager.OnGameStart.RemoveListener(() => this.Wait(3f, getTutorial));

    }
    #endregion
    #region Private Methods
    private void getTutorial()
    {
        LevelManager.Instance.IsLevelStarted = false;
        tutorialText.text = "Catch The Cars and Save The Pedestrians!";
        ShowPanel();
    }

    #endregion

}


