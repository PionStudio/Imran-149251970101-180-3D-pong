using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode leftInputKey;
    [SerializeField] private KeyCode rightInputKey;

    [SerializeField] private float moveSpeed;

    private Rigidbody myRb;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement(GetInput());
    }

    private void Movement(Vector3 direction)
    {
        myRb.velocity = direction * moveSpeed;
    }

    private Vector3 GetInput()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(leftInputKey))
        {
            return direction = -transform.forward;
        }

        if (Input.GetKey(rightInputKey))
        {
            return direction = transform.forward;
        }

        return direction;
    }
}
