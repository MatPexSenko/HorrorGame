using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private string[] Text;
    [SerializeField] private float SpeedText;
    [SerializeField] private Text DialogeText;
    [SerializeField] private GameObject _cam;
    [SerializeField] private float _distance = 2f;
    [SerializeField] private int index;
    [SerializeField] private bool _isInteract = false;
    private void Start()
    {
        DialogeText.text = string.Empty;
    }

    IEnumerator TypeLine()
    {
        foreach (char a in Text[index].ToCharArray())
        {
            DialogeText.text += a; 
            yield return new WaitForSeconds(SpeedText);
        }
    }
    void StartDialoge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void sciptext()
    {
        if (DialogeText.text == Text[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            DialogeText.text = Text[index];
        }
    }
    private void NextLine()
    {
        if (index < Text.Length - 1)
        {
            index++;
            DialogeText.text += string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        if (Physics.Raycast(ray, out hit, _distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_isInteract)
                {
                    StartDialoge();
                    _isInteract= false;
                }
            }
        }
    }
}
