using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ProgressBar : Panel
{
    [SerializeField] Image progressFillImage;
    void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        progressFillImage.fillAmount = 0f;

        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.AddListener(HidePanel);

        EventManager.OnSceneLoaded.AddListener(() => progressFillImage.fillAmount = 0f);
        EventManager.OnCharacterEndOfPath.AddListener(UpdateLevelProgress);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
        EventManager.OnSceneLoaded.RemoveListener(() => progressFillImage.fillAmount = 0f);
        EventManager.OnCharacterEndOfPath.RemoveListener(UpdateLevelProgress);
    }

    public void UpdateLevelProgress()
    {
        float val = 1f - ((float)EndCheck.reachPedestrianCount / (float)LevelManager.Instance.CurrentLevel.pedestrianCount);
        progressFillImage.DOFillAmount(val, .8f);
    }
}
