using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private float _distance = 2f;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _point;
    //[SerializeField] private AudioSource _sound;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        if (Physics.Raycast(ray, out hit, _distance))
        {

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject == this.gameObject)
            {
                this._animator.Play("Items");
              //this._sound.Play();

            }
        }
    }
}
