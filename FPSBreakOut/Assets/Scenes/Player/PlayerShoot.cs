using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GameObject prefab;
    [SerializeField] private Transform playerBody;

    void Awake()
    {
        prefab = Resources.Load("Ball/ball") as GameObject;//easy load for projectiles
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
            projectile.transform.position = playerBody.position + transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 40;
        }
    }
}
