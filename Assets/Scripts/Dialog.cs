using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public string[] Text;
    public float SpeedText;
    public Text DialogeText;

    public int index;
    private void Start()
    {
        DialogeText.text = string.Empty;
        StartDialoge();
    }

    IEnumerator TypeLine()
    {
        foreach (char a in Text[index].ToCharArray()) {
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
        if(DialogeText.text == Text[index])
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
        if(index < Text.Length-1) {
            index++;
            DialogeText.text+= string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
