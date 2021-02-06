using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [SerializeField] Text nextLevelText = default;
    [SerializeField] Text currentLevelText = default;

    private void OnEnable()
    {
        EventManager.OnLevelChange.AddListener(SetLevelProgressText);
    }
    private void OnDisable()
    {
        EventManager.OnLevelChange.RemoveListener(SetLevelProgressText);
    }

    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }
}
