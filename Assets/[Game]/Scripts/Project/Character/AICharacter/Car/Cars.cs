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
        gameObject.transform.SetParent(CarSpawner.vehiclesAll);
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
    //void Start() 
    //{
    //    addToTarget();
    //}
    private void OnEnable()
    {
        CarManager.Instance.AddCar(this);

        delay = Random.Range(0f,2f);
        EventManager.OnCarCreate.AddListener(() => this.Wait(delay, Movement));     
    }

    private void OnDisable()
    {
        //CarManager.Instance.RemoveCar(this); ====> bu kısımdan çok emin değilim sorun yaratabilir

        EventManager.OnCarCreate.RemoveListener(() => this.Wait(delay, Movement));
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
        //gameObject.transform.SetParent(vehiclesAll.transform);/// ulaşınca pool sistemi dolayısıyla tekrar arabaları v
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
