using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool gravityReversed = false; //gravity is currently reversed
    public bool canChange = true;

    public bool canDrop = false;
    public Transform pickUpTransform;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        Debug.Log("Started!");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        if (gravityReversed)
        {
            direction.y = 1f;
        }
        else
        {
            direction.y = -1f;
        }

        controller.Move(direction.normalized * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && canChange)
        {
            gravityReversed = !gravityReversed;
            canChange = false;
        }

        if (Input.GetKey(KeyCode.E) && canDrop)
        {
            pickUpTransform.parent = null;
            pickUpTransform = null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Ceiling");
            canChange = true;
        }

        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground");
            canChange = true;
        }

        if (other.gameObject.tag == "Movable")
        {
            other.transform.parent = this.transform;
            pickUpTransform = other.transform;
            canDrop = true;
        }
    }
}