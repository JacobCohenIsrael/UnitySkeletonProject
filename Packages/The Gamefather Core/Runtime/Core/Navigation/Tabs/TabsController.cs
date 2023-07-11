using System;
using JCI.Core.Extensions;
using UnityEngine;

namespace JCI.Core.Navigation.Tabs
{
    public class TabsController : MonoBehaviour
    {
        [SerializeField] private TabPanel defaultTabPanel;
        [SerializeField] private TabToggle[] toggles;

        private TabPanel activeTabPanel;
        
        private void Awake()
        {
            activeTabPanel = defaultTabPanel;
            foreach (var tabToggle in toggles)
            {
                tabToggle.tabPanel.SetActive(false);
                tabToggle.tabButtonClicked += TabButtonClicked;
            }
            activeTabPanel.SetActive(true);
        }

        private void TabButtonClicked(TabPanel panel)
        {
            activeTabPanel.SetActive(false);
            activeTabPanel = panel;
            activeTabPanel.SetActive(true);
        }
    }
}