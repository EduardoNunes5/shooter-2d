
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Combat/Wave")]
public class WaveSO : ScriptableObject
{
    public List<AirCraftSpawnData> enemies;
}

[System.Serializable]
public class AirCraftSpawnData
{
    public Enemy prefab;
    public SpawnLocationsEnum spawnLocation;
    public float spawnDelay;

}

public enum SpawnLocationsEnum
{
    TopLeft, CenterLeft, Center, CenterRight, TopRight,
}