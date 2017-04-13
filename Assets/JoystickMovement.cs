using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour {


    [SerializeField] private Transform foot;
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField]
    private float jumpForce;
    public bool noAxisInput;
    public bool isSidescrolling;

    #region Privates

    [SerializeField]
    public Vector3 velocity;
    private Rigidbody rigid;
    private float rigidY;
    #endregion

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start() {


    }
    Vector3 movement;

    private bool canMove = true;
    // Update is called once per frame
    void Update() {

        float h = Input.GetAxis("Horizontal");

        float v;
        if (isSidescrolling)
        {
            v = 0f;
        }
        else
        {
            v = Input.GetAxis("Vertical");
        }
        movement = new Vector3(h, 0.0f, v);
        if (!canMove) {
            movement = Vector3.zero;
        }
        rigidY = rigid.velocity.y;

        velocity = rigid.velocity;

        noAxisInput = false;

        if (Mathf.Approximately(h, 0f))
        {
            if (Mathf.Approximately(v, 0f))
            {
                noAxisInput = true;
            }

        }


        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;
        movement = movement.normalized;

        isGrounded = IsGrounded();

        rigid.velocity = movement * speed;
    }


    RaycastHit hitInfo;
    bool isGrounded;
    bool isFalling=false;
    float sphereRadius = 0.1f;

    public bool IsGrounded()
    {
        Collider[] cols = Physics.OverlapSphere(foot.transform.position, sphereRadius);
        for (int i = 0; i < cols.Length; i++) {
            if (cols[i].gameObject.layer == LayerMask.NameToLayer("Ground")) {
                return true;
            }
        }

        rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y - gravity * Time.deltaTime, rigid.velocity.z);
        return false;
    }

    public void Jump()
    {
        rigid.velocity = new Vector3(rigid.velocity.x, jumpForce, rigid.velocity.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(foot.transform.position, sphereRadius);
    }
}
