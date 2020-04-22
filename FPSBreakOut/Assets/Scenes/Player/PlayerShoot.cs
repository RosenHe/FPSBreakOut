using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private GameObject effectToSpawn; //firing effect 
  
    GameObject prefab;
    Transform firePoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float ballSpeed = 20;


    void Awake()
    {
        prefab = Resources.Load("Ball/ball") as GameObject;//easy load for projectiles

        firePoint = player.GetComponentInChildren<Transform>().GetChild(0).GetChild(0);
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))// makes balls
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.transform.forward * ballSpeed;
        }
    }
}
