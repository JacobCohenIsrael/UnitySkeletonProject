using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace JCI.Core.Navigation.Tabs
{
    public class TabToggle : MonoBehaviour
    {
        [SerializeField] public Button tabButton;
        [SerializeField] public TabPanel tabPanel;

        public UnityAction<TabPanel> tabButtonClicked;
        
        private void Awake()
        {
            tabButton.onClick.AddListener(HandleTabToggle);
        }

        private void OnDestroy()
        {
            tabButton.onClick.RemoveListener(HandleTabToggle);

        }

        private void HandleTabToggle()
        {
            tabButtonClicked.Invoke(tabPanel);
        }
    }
}