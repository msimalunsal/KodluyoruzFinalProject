using DG.Tweening;
using UnityEngine;

public class Cars : Character, Killable
{
    #region Constructor
    public Cars() : base(CharacterControllerType.AI) { }
    #endregion

    #region Public methods from interfaces
    public void Kill()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        playerData.CoinAmount += 10;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        Debug.Log(playerData.CoinAmount);
        moveTween.Kill();
    }
    #endregion

    #region SerializeFields
    [SerializeField] GameObject targetPointObj = default;
    #endregion

    #region Private Field
    Vector3[] targetPoints;
    int index = 0;

    float delay;
    public Tween moveTween;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        CarManager.Instance.AddCar(this);

        addToTarget(targetPointObj);

        delay = Random.Range(0f,2f);
        EventManager.OnCharacterCreate.AddListener(() => this.Wait(delay, Movement));     
    }

    private void Destroy()
    {
        if (Managers.Instance == null)
            return;

        CarManager.Instance.RemoveCar(this);

        EventManager.OnCharacterCreate.RemoveListener(() => this.Wait(delay, Movement));
    }

    void Movement()
    {
        if (IsDead == true)
            return;

        transform.LookAt(targetPoints[index]);
        moveTween = transform.DOMove(targetPoints[index], 2f)
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                if (index < targetPoints.Length - 1)
                {
                    index++;
                    Movement();
                }                    
            });
    }

    public void addToTarget(GameObject gameObject)
    {
        targetPoints = new Vector3[targetPointObj.transform.childCount];
        for(int x = 0; x < targetPointObj.transform.childCount; x++)
        {
            targetPoints[x] = targetPointObj.transform.GetChild(x).gameObject.transform.position;
        }
    }

    #endregion
}
