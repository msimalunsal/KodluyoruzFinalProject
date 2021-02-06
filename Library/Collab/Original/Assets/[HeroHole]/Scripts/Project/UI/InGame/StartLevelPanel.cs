using UnityEngine;

public class StartLevelPanel : Panel
{
    #region Private Methods
    void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        HidePanel();
        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnLevelStart.AddListener(HidePanel);
        EventManager.OnChangeLevel.AddListener(ShowPanel);
    }

    void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(ShowPanel);
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        EventManager.OnChangeLevel.RemoveListener(ShowPanel);
    }
    #endregion
}
