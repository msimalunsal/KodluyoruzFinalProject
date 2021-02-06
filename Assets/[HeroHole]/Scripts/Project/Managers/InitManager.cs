using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : Singleton<InitManager>
{
    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync(PlayerPrefs.GetString("UI", "UI"), LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(PlayerPrefs.GetString("LastLevel", "Level01"), LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(PlayerPrefs.GetString("LastLevel", "Level01")));
        Destroy(gameObject);
    }
}
