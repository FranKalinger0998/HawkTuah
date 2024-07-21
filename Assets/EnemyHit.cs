
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Material[] defaultMaterials;
    
    public Renderer enemyRenderer;
    private Material[] hitMaterials;

    public Material hitMaterial;

    void Start()
    {
       
        defaultMaterials = enemyRenderer.materials;
        hitMaterials = new Material[defaultMaterials.Length];
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            hitMaterials[i] = new Material(hitMaterial);
        }
    }

    
    public void DamageEnemyEffects()
    {
        enemyRenderer.materials = hitMaterials;
        Invoke("ResetColor", 0.1f);
    }
  

    void ResetColor()
    {
        enemyRenderer.materials = defaultMaterials;
        
    }
}
