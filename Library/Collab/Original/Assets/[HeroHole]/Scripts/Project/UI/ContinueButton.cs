using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ContinueButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();

        onClick.AddListener(() => LevelManager.Instance.FinishLevel());
        onClick.AddListener(ContinueLevel);
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        onClick.RemoveListener(() => LevelManager.Instance.FinishLevel());
        onClick.RemoveListener(ContinueLevel);
    }

    void ContinueLevel()
    {
        LevelManager.Instance.LoadNextScene();
        EventManager.OnChangeLevel.Invoke();
    }

}
