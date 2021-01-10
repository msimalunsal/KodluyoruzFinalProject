using UnityEngine;

public abstract class SpawnerPointsBase : MonoBehaviour
{
    #region Protected Fields
    protected float delay;
    protected Character character;
    protected Transform pointTransform;
    #endregion

    #region Protected Methods
    protected void OnEnable()
    {
        delay = Random.Range(0, 5f);
        EventManager.OnLevelStart.AddListener(() => this.Wait(delay, Spawn));
    }

    protected void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(() => this.Wait(delay, Spawn));
    }
    #endregion

    #region Virtual Methods
    /// <summary>
    /// It spawns the character given at transform point that given
    /// </summary>
    protected virtual void Spawn()
    {
        CharacterManager.Instance.setEnabled(character, pointTransform);
    }
    #endregion
}
