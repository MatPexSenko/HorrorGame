using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private float _vinput;
    private float _hinput;

    private Rigidbody _rb;


    private float _moveSpeed = 4f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Возвращаем компонент rigidbody
    }
    void FixedUpdate()
    {
        _vinput = Input.GetAxis("Vertical") * _moveSpeed;

        _hinput = Input.GetAxis("Horizontal") * _moveSpeed;

        this.transform.Translate(Vector3.forward * _vinput * Time.deltaTime);

        this.transform.Translate(Vector3.right * _hinput * Time.deltaTime);

        
    }
}
