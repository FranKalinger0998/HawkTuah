using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="ScriptableFriendly")]
public class LlamaData : ScriptableObject
{
    public int baseFireSpeed;
    public GameObject llamaPrefab;
    public int baseDamage;
    public LamaType type;
    
}
