using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody2D projectilePrefab;
    public float firerate = 0.3f;
    private float currentFireTimer = 0;
    private bool isFiringButtonDown = false;
    public float shootForce = 1f;
    public float bulletDeathTimer = 1f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
         if (!projectilePrefab) {
            Debug.LogWarning("Please give the " + gameObject.name + " PlayerShooter script a projectile reference");
        }
        currentFireTimer = firerate;
    }

    // Update is called once per frame
    void Update()
    {
        isFiringButtonDown = Input.GetButton("Jump");

        currentFireTimer += Time.deltaTime;

        if (isFiringButtonDown) {
            if (currentFireTimer >= firerate) {
                FireOneBullet();
                currentFireTimer = 0;
            }
        }
    }

    private void FireOneBullet() {
        Rigidbody2D rg = Instantiate<Rigidbody2D>(projectilePrefab, transform.position, player.transform.rotation);
        rg.AddRelativeForce(10 * shootForce * UnityEngine.Vector2.up);
        Destroy(rg.gameObject, bulletDeathTimer+10);
    }
    
}
