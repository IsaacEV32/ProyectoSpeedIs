using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Vehicle : MonoBehaviour
{
    float speedMax = 200;
    public float currentSpeed = 0;
    float speedRotation = 1;
    Rigidbody rb;
    Vector3 direction;
    Vector3 directionRotacion;
    bool isPressedForward = false;
    bool isPressedRight = false;
    bool isPressedLeft = false;
    bool isPressedBack = false;
    bool isPressedSpace = false;
    KeyCode lastKey = KeyCode.None;
    KeyCode actualKey = KeyCode.None;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float directionX = Input.GetAxis("Vertical");
        float directionY = Input.GetAxis("Horizontal");
        direction = new Vector3(directionX, 0);
        directionRotacion = new Vector3(0, directionY, 0);
        if (Input.GetKey(KeyCode.W))
        {
            isPressedForward = true;
            actualKey = KeyCode.W;
            lastKey = KeyCode.W;
        }
        else
        {
            isPressedForward = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isPressedBack = true;
            actualKey = KeyCode.S;
            lastKey = KeyCode.S;
        }
        else
        {
            isPressedBack = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            lastKey = KeyCode.W;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            lastKey = KeyCode.S;
        }
        //Aqui esta el control del derrape
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressedSpace = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressedSpace = false;
            rb.AddForce(transform.forward * (-rb.linearVelocity.z), ForceMode.Force);
        }
    }
    private void FixedUpdate()
    {
        Debug.Log(rb.linearVelocity);
        if (currentSpeed < speedMax && (isPressedForward || isPressedBack) && actualKey == lastKey)
        {
            currentSpeed += 1;

        }
        else if (currentSpeed >= speedMax && (isPressedForward || isPressedBack) && actualKey == lastKey)
        {
            currentSpeed = speedMax;

        }
        else if (currentSpeed <= speedMax && (isPressedForward || isPressedBack) && actualKey != lastKey)
        {
            currentSpeed = 0;
            currentSpeed += 1;
        }
        if (!isPressedForward && !isPressedBack)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= 1;
            }
            else if (currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
        }
        transform.rotation *= Quaternion.Euler(directionRotacion.normalized * speedRotation);
        rb.AddForce(transform.right * direction.normalized.x * currentSpeed - rb.linearVelocity, ForceMode.Force);
        //Aqui esta la logica del derrape
        if (isPressedSpace)
        {
            rb.AddForce(transform.forward * -directionRotacion.normalized.y * 10 - rb.linearVelocity, ForceMode.Force);
        }
    }
    internal void AddBoostOfSpeed(Transform directionOfBooster)
    {
        rb.AddForce(directionOfBooster.forward * 20, ForceMode.Impulse);
    }
}
