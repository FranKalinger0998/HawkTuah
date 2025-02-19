using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBabiesScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.RemoveLife();
        }
    }
}
