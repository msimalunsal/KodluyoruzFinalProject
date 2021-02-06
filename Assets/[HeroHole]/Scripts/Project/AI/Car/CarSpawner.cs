using UnityEngine;

public class CarSpawner : SpawnerBase
{
    #region SerializeField
    [SerializeField] GameObject vehiclesAll;
    #endregion

    private void Start()
    {
        if(vehiclesAll != null)
            parentObj = vehiclesAll;
    }
}
