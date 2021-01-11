public class PedestrianSpawnerPoint : SpawnerPointsBase
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        
        base.OnEnable();

        character = PedestrianManager.Instance.GetRandomPedestrian();
        pointPosition = transform.position;
    }
}
