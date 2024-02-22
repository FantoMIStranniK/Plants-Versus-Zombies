using UnityEngine;

namespace PVZ.UI
{
    public class PlantsMenuDropDown : MonoBehaviour
    {
        [SerializeField] private GameObject plantsMenu;
        [Space]
        [SerializeField] private GameObject showMenuButton;

        private bool _isInMenu = false;

        public void ChangeMenuState()
        {
            if (plantsMenu == null || showMenuButton == null)
                return;

            _isInMenu = !_isInMenu;

            if (_isInMenu)
            {
                plantsMenu.SetActive(true);
                showMenuButton.SetActive(false);
            }
            else
            {
                plantsMenu.SetActive(false);
                showMenuButton.SetActive(true);
            }
        }
    }
}