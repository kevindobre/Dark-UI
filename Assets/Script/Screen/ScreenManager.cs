using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using core.Singleton;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screensBases;
        public Screentype startScreen = Screentype.Panel;

        private ScreenBase _currentScreen;
        private void Start()
        {
            HideAll();
            ShowByType(startScreen);

        }

        public void ShowByType(Screentype type)
        {
            if (_currentScreen != null) _currentScreen.Hide();

            var nextScreen = screensBases.Find(i => i.screenType == type);

            nextScreen.Show();
            _currentScreen = nextScreen;

        }
        public void HideAll()
        {
            screensBases.ForEach(i => i.Hide());
        }
    }
}
