using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="ScriptableEnemy")]
public class EnemyData : ScriptableObject
{
    public int speedModifier;
    public float health;
    public GameObject enemyPrefab;
    public int level;
}
