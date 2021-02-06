using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Level Data")]
public class Level : ScriptableObject
{
    [Header("Pedestrian Data")]
    public List<PedestrianData> pedestrians = new List<PedestrianData>();
    public int pedestrianCount;

    [Header("Car Data")]
    public List<CarData> cars = new List<CarData>();

}
