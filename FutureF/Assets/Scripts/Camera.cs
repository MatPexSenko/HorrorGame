using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform target;
    public Vector3 camOffset = new Vector3(0.2f, 0f, 0f);
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float rotationX;
    [SerializeField] private float rotationY;
    [SerializeField] private float maxRotation;
    [SerializeField] private float minRotation;
    private Transform PlayerBody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAxis();
        SetRotation();

    }
    private void GetAxis()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;
    }
    private void SetRotation()
    {

        rotationX -= mouseY;
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        rotationX = Mathf.Clamp(rotationX, (maxRotation * -1), (minRotation * -1));
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
