using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public bool gravityChange = false; //gravity is currently changing
    public bool gravityReversed = false; //gravity is currently reversed

    private void Start()
    {
        Debug.Log("Started!");
    }

    void Update()
    {
        if (gravityChange)
        {
            if (!gravityReversed)
            {
                controller.Move(new Vector3(0f, 1f, 0f) * 10.0f * Time.deltaTime);
            }
            else
            {
                controller.Move(new Vector3(0f, -1f, 0f) * 10.0f * Time.deltaTime);
            }
        }
        else
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                controller.Move(direction * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                gravityChange = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gravityReversed && other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Ceiling");
            gravityReversed = true;
            gravityChange = false;
        }

        if (gravityReversed && other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground");
            gravityReversed = false;
            gravityChange = false;
        }
    }
}
