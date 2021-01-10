using UnityEngine;

public class CarSpawnerPoint : SpawnerPointsBase
{
    private void OnEnable()
    {
        base.OnEnable();
        character = CarManager.Instance.GetRandomCar();
        pointTransform = transform;
    }
}
