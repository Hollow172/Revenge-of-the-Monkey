using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New level", menuName = "Level")]
public class ScriptableLevel : ScriptableObject
{
    public int MaxAmountOfWaves = 6;
    public int MultiplierOfEnemies = 3;
    public int CooldownBetweenSpawn = 3;
    public int CooldownBetweenWaves = 5;
}

