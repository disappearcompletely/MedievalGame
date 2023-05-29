using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageScript : MonoBehaviour
{
    public int damageCount = 40;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FindObjectOfType<PlayerManager>().Damage(damageCount));
    }
}
