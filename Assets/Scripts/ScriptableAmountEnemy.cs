using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy per wave", menuName = "Enemy per wave")]
public class ScriptableAmountEnemy : ScriptableObject
{
    public List<int> EnemyPerWave;
}
