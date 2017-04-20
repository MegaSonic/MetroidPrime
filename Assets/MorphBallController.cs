using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphBallController : MonoBehaviour {

    public float moveForce;
    public float jumpForce;

    public Transform thirdPerson;
    public Transform lookAt;
    public Camera thirdPersonCamera;
    public Transform foot;

    public Vector3 velocity;



    public bool canMove;
    public bool noAxisInput;
    public bool isGrounded;

    public bool usedBombJump;

    private Vector3 movement;
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Switch"))
        {
            thirdPerson.gameObject.SetActive(true);
            thirdPerson.gameObject.transform.SetParent(null);
            this.gameObject.transform.SetParent(thirdPerson);
            this.gameObject.SetActive(false);
            thirdPersonCamera.depth = -1;
            thirdPerson.transform.rotation = this.transform.rotation;
        }

        isGrounded = IsGrounded();
        if (isGrounded)
        {
            usedBombJump = false;

            if (Input.GetButtonDown("Jump"))
            {
                rigid.AddForce(Vector3.up * jumpForce);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && !usedBombJump)
            {
                usedBombJump = true;
                rigid.AddForce(Vector3.up * jumpForce);
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        movement = new Vector3(h, 0.0f, v);
        if (!canMove)
        {
            movement = Vector3.zero;
        }

        velocity = rigid.velocity;

        noAxisInput = false;

        if (Mathf.Approximately(h, 0f))
        {
            if (Mathf.Approximately(v, 0f))
            {
                noAxisInput = true;
            }

        }


        movement = thirdPersonCamera.transform.TransformDirection(movement);
        movement.y = 0f;
        movement = movement.normalized;

        
    }

    private void FixedUpdate()
    {
        rigid.AddForce(movement * moveForce);
    }


    public bool IsGrounded()
    {
        Collider[] cols = Physics.OverlapSphere(foot.transform.position, 0.1f);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                return true;
            }
        }
        return false;
    }
}
