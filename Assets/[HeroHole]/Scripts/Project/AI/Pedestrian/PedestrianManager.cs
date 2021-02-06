using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PedestrianManager : Singleton<PedestrianManager>, ISubscribe<Pedestrian>
{
    List<Pedestrian> pedestrians = new List<Pedestrian>();
    
    public void AddList(Pedestrian t)
    {
        if (!pedestrians.Contains(t))
            pedestrians.Add(t);
    }

    public void RemoveList(Pedestrian t)
    {
        if (pedestrians.Contains(t))
            pedestrians.Remove(t);
    }
}
