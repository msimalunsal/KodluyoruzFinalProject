using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianManager : Singleton<PedestrianManager>
{
    List<Pedestrian> pedestrians = new List<Pedestrian>();

    public Pedestrian GetRandomPedestrian()
    {
        int randIndex = Random.Range(0, pedestrians.Count);
        return pedestrians[randIndex];
    }
}
