using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private float _distance = 2f;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _sound;
    private bool _isOpen=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        if (Physics.Raycast(ray, out hit, _distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_isOpen)
                {
                    _animator.SetBool("isOpen", true);
                    _isOpen = false;
                }
                else
                {
                    _animator.SetBool("isOpen", false);
                    _isOpen = true;
                }
                _sound.Play();
                
            }
        }
    }
}
