using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens 
{
    public enum Screentype
    {
        Panel,
        Info_Panel,
        shop,
        Settings,
        facebook,
        Ranking
    }
}
public class ScreenBase : MonoBehaviour
{
    public Screens.Screentype screenType;

    public List<Transform> listOfObjects;
    public List<Typper> listOfPhases;

    public bool startHided = false;

    [Header("Animations")]
    public float DelayBetweenObjects = 0.3f;
    public float animationDuration = 0.5f;

    public Image uiBackground;

    [Button]
    public virtual void Show()
    {
        Debug.Log("Show Screen");
        ShowObjects();
    }
    
    [Button]
    public virtual void Hide()
    {
        Debug.Log("Hide Screen");
        HideObjects();
    }

    private void HideObjects()
    {
        listOfObjects.ForEach(obj => obj.gameObject.SetActive(false));
        uiBackground.enabled = false;

    }

    private void ForceShowObjects()
    {
        listOfObjects.ForEach(obj => obj.gameObject.SetActive(true));
        uiBackground.enabled = true;

    }

    private void ShowObjects()
    {
        for(int i = 0; i < listOfObjects.Count; i++)
        {
            var obj = listOfObjects[i];

            obj.gameObject.SetActive(true);
            obj.DOScale(0, animationDuration).From().SetDelay(i * DelayBetweenObjects);
        }
        Invoke(nameof(StartType), DelayBetweenObjects * listOfObjects.Count + animationDuration);
        uiBackground.enabled = true;
    }

    private void StartType()
    {
        for (int i = 0; i < listOfPhases.Count; i++)
        {
            listOfPhases[i].StartType();
        }
    }
}
