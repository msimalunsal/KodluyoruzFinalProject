using UnityEngine;
using PathCreation.Examples;

public class Pedestrian : MonoBehaviour, Killable
{
    private void Start()
    {
        PedestrianManager.Instance.AddList(this);
    }

   
    public void Kill()
    {
        //GetComponent<Animator>().SetBool("isWalking", false);
        //GetComponent<Animator>().SetBool("isDead", true);
        ClosePath();
        LevelManager.Instance.FailLevel();
    }

    public void ClosePath()
    {
        GetComponent<PathFollower>().enabled = false;
    }
}
