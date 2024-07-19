using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    crawler,
    runner,
    mother
}
[CreateAssetMenu(menuName ="ScriptableEnemy")]
public class EnemyData : ScriptableObject
{
    public int speedModifier;
    public float health;
    public GameObject enemyPrefab;
    public EnemyType enemyType;
}
