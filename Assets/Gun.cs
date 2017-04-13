using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform bulletSpawnPoint;
    public GameObject bullet;

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Bullet bulletComponent = bulletObject.GetComponent<Bullet>();
            bulletComponent.Shoot(bulletSpawnPoint.up);
        }
	}
}
