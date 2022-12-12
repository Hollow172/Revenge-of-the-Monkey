using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New level", menuName = "Level")]
public class ScriptableLevel : ScriptableObject
{
    public int MaxAmountOfWaves = 6;
    public int MultiplierOfEnemies = 3;
    public float CooldownBetweenWaves = 5;
    public List<float> CooldownBetweenSpawn;
    public List<GameObject> EnemiesToSpawn;
}

