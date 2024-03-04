using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private float _distance = 2f;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _sound;
    void Start()
    {

    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        if (Physics.Raycast(ray, out hit, _distance))
        {
            
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject==this.gameObject)
            {
                if (_animator.GetBool("isOpen")==false && hit.collider.gameObject.tag=="Door")
                {
                    
                    this._animator.SetBool("isOpen", true);
                    this._sound.Play();
                    Debug.Log(this.gameObject);
                }
                else
                {
                    this._animator.SetBool("isOpen", false);
                    this._sound.Play();
                }

            }
        }
    }
}
