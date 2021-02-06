using UnityEngine;

public class EndCheck : MonoBehaviour
{
    #region SerializeField
    int pedestrianAll;
    [SerializeField] ParticleSystem confetti;
    #endregion

    public static int allPedestrianCount;
    public static int reachPedestrianCount;
    private void Start()
    {
        if (Managers.Instance == null)
            return;

        allPedestrianCount = LevelManager.Instance.CurrentLevel.pedestrianCount;
        reachPedestrianCount = allPedestrianCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<Pedestrian>();
        if (obj != null)
            if (reachPedestrianCount > 1)
            {
                reachPedestrianCount--;
                EventManager.OnCharacterEndOfPath.Invoke();
                confetti.Play();
            }
            else
            {
                reachPedestrianCount = 0;
                EventManager.OnCharacterEndOfPath.Invoke();
                confetti.Play();
                LevelManager.Instance.FinishLevel();
            }             
    }
}
