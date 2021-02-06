using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailLevelPanel : Panel
{
    void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        HidePanel();
        EventManager.OnLevelFail.AddListener(ShowPanel);
        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFail.RemoveListener(ShowPanel);
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        HidePanel();
    }
}
