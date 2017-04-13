using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public Rigidbody rigid;

    private float deathTimer;

	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        IShootable shootable = other.GetComponent<IShootable>();
        if (shootable != null)
        {
            shootable.Shoot();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        deathTimer += Time.deltaTime;
        if (deathTimer > 10f) Destroy(this.gameObject);    
    }

    public void Shoot(Vector3 direction)
    {
        rigid.velocity = direction * speed;
    }
}
