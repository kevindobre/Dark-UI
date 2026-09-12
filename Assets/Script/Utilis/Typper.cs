using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using TMPro;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float typingBetweenLetters = .1f;
    public string phrase;

    private void Awake()
    {
        textMesh.text = "";
    }

    [NaughtyAttributes.Button]
    public void StartType()
    {
        StartCoroutine(type(phrase));
    }

    IEnumerator type(string s)
    {
        textMesh.text = "";
        foreach (char i in s.ToCharArray())
        {
            textMesh.text += i;
            yield return new WaitForSeconds(typingBetweenLetters);
        }
    }
}
