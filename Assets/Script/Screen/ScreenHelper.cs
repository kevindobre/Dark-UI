using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public Screentype screentype;

        public void Onclick()
        {
            ScreenManager.Instance.ShowByType(screentype);
        }
    }
}

