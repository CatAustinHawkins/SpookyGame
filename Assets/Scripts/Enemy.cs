using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject CombatManager;
    public void OnTriggerEnter(Collider other)
    {
        CombatManager.GetComponent<CombatManager>().CombatBegin();
        Destroy(gameObject);
    }

}
