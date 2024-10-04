using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Allows usewrs to modify damage
    [SerializeField] private float damageDealt;
    
    // returns damage dealt when called
    public float GetDamage(){
        return damageDealt;
    }
}
