using System;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    [Header("Beep beep")]
    [SerializeField] private AudioClip beepBeepClip;
    [SerializeField] private AudioSource beepBeepSource;

    [Header("Car Motion")]
    [SerializeField] private float acceleration = 12;
    [SerializeField] private float rotationSpeed = 24;
    [SerializeField] private float maxSpeed = 16;
    [SerializeField] private float stopBrake = 1.5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.drag = stopBrake;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody.drag = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            beepBeepSource.PlayOneShot(beepBeepClip);
        }
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        _rigidbody.AddForce(transform.forward * (acceleration * _rigidbody.mass * verticalInput));
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // _rigidbody.velocity -> velocidad (Vector3)
        // speed -> rapidez (float -> número decimal)
    }
}
