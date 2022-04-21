using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6.0f;
    public bool gravityChange = false; //gravity is currently changing
    public bool gravityReversed = false; //gravity is currently reversed
    public bool canChange = true;

    private void Start()
    {
        Debug.Log("Started!");
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        if (!gravityReversed)
        {
            direction.y = -1f;
        }
        else
        {
            direction.y = 1f;
        }

        controller.Move(direction * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && canChange)
        {
            gravityReversed = !gravityReversed;
            canChange = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ceiling")
        {
            Debug.Log("Ceiling");
            Debug.Log(other.relativeVelocity);
            canChange = true;
        }

        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground");
            Debug.Log(other.relativeVelocity);
            canChange = true;
        }
    }
}