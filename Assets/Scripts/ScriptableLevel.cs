using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New level", menuName = "Level")]
public class ScriptableLevel : ScriptableObject
{
    public int MaxAmountOfWaves = 6;
    public float CooldownBetweenWaves = 5;
    public float SecondsBeforeWaves = 2.5f;
    public float SpawnRate = 2f;
}

