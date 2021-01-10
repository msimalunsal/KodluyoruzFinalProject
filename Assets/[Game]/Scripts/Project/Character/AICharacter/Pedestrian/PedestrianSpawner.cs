using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnerPoint = default;

    public static List<Pedestrian> pedestrians = new List<Pedestrian>();

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(Spawner);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(Spawner);
    }

    public static void AddList(Pedestrian pedestrian)
    {
        if (!pedestrians.Contains(pedestrian))
        {
            pedestrians.Add(pedestrian);
        }
    }

    public static void RemoveList(Pedestrian pedestrian)
    {
        if (pedestrians.Contains(pedestrian))
            pedestrians.Remove(pedestrian);
    }

    void Spawner()
    {
        Debug.Log("Ben dogdum");
        foreach (var each in pedestrians)
        {
            //Instantiate(each, spawnerPoint);
            each.gameObject.transform.localPosition = spawnerPoint.position;
            Debug.Log("Ben dogdum");
        }
    }
}
