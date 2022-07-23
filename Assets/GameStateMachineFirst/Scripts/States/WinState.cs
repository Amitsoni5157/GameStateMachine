using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace GameStateMachine
{
    public class WinState : MonoBehaviour
    {
        public UnityAction<WinState> OnClickMenuButton;
        public UnityAction<WinState> OnClickNectLevelButton;
        public TextMesh State_Text;
        public Button button_Menu;
        public Button button_NextLevel;
        public bool MenuChoose;

        private void OnEnable()
        {
            button_Menu.onClick.AddListener(ClickOnMenuButton);
            button_NextLevel.onClick.AddListener(ClickOnNextLevelButton);
        }

        private void ClickOnNextLevelButton()
        {
            MenuChoose = false;
            OnClickNectLevelButton?.Invoke(this);
        }

        private void ClickOnMenuButton()
        {
            MenuChoose = true;
            OnClickMenuButton?.Invoke(this);
        }

        public void Init(string stateName)
        {
            State_Text.text = stateName;
        }

        private void OnDisable()
        {
            button_Menu.onClick.RemoveListener(ClickOnMenuButton);
            button_NextLevel.onClick.RemoveListener(ClickOnNextLevelButton);
        }
    }
}