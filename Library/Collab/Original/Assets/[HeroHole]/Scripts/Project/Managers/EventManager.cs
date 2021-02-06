using UnityEngine.Events;

public static class EventManager
{
    #region Game State Events
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameOver = new UnityEvent();
    #endregion

    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnChangeLevel = new UnityEvent();
    #endregion

    #region Data Events
    public static PlayerDataEvent OnPlayerDataUpdated = new PlayerDataEvent();
    #endregion

    #region Spawn Events
    public static UnityEvent OnPedestrianCreate = new UnityEvent();
    public static UnityEvent OnCarCreate = new UnityEvent();
    #endregion

    #region Character Events
    public static UnityEvent OnCharacterEndOfPath = new UnityEvent();
    #endregion
}
public class PlayerDataEvent : UnityEvent<PlayerData> { }