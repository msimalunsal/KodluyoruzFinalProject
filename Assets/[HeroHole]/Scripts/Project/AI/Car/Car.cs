using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour,Killable
{
    public GameObject endPointdefault ;
    public GameObject vehiclesAll;

    private void OnEnable()
    {
        Transform parent = transform.parent;
        endPointdefault = parent.GetChild(1).gameObject;
    }
    public void Kill()
    {
        ClosePath();
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        playerData.CoinAmount += 10;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
    }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.GetComponent<Pedestrian>() != null)
        {
            collision.gameObject.GetComponent<Killable>().Kill();
            LevelManager.Instance.FailLevel();
        }
    }

    public void ClosePath()
    {
        GetComponent<PathFollower>().enabled = false;
    }
}
