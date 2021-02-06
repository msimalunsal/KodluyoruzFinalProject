using UnityEngine;

public class PedestrianSpawner : SpawnerBase
{
    #region SerializeField
    [SerializeField] GameObject pedestrianAll;
    #endregion

    private void Start()
    {      
        if(pedestrianAll != null)
            parentObj = pedestrianAll;
    }
}
