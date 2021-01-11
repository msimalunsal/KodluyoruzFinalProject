using UnityEngine;

public class CarSpawnerPoint : SpawnerPointsBase
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        base.OnEnable();

        character = CarManager.Instance.GetRandomCar();
        character.enabled = false;
        pointPosition = transform.position;
    }
}
