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

    }

    // Update is called once per frame
    void Update () {
        deathTimer += Time.deltaTime;
        if (deathTimer > 10f) Destroy(this.gameObject);

        RaycastHit info = new RaycastHit();
        Debug.DrawRay(transform.position, rigid.velocity * Time.deltaTime, Color.green);
        if (Physics.Raycast(this.transform.position, rigid.velocity, out info, rigid.velocity.magnitude * Time.deltaTime))
        {
            IShootable shootable = info.collider.GetComponent<IShootable>();
            if (shootable != null)
            {
                shootable.Shoot();
                Destroy(this.gameObject);
            }

            if (info.collider != null)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Shoot(Vector3 direction)
    {
        
        rigid.velocity = direction * speed;
    }
}
