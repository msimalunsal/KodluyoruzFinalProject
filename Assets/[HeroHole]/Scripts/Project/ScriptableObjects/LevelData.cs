using System.Collections.Generic;
using UnityEngine;

public enum LevelAIType { Pedestrian, Car }

[System.Serializable]
public class LevelAIData
{
    public LevelAIType LevelAIType;

    public List<GameObject> AIToCreate = new List<GameObject>();
}

[System.Serializable]
public class PedestrianData
{
    public List<GameObject> pedestrianPrefabs;
}

[System.Serializable]
public class CarData
{
    public List<GameObject> carPrefabs;
}

[CreateAssetMenu(fileName = "Level Data", menuName = "Hero Hole/Level Data")]
public class LevelData : ScriptableObject
{
    public List<Level> Levels = new List<Level>();
}
