using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damageDealt;

    public float GetDamage(){
        return damageDealt;
    }
}
