using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameStateMachine
{
    public class MenuState : MonoBehaviour
    {
        public UnityAction<MenuState> OnMenuComplete;
        public UnityAction<MenuState> OnPauseButton;
        public TextMesh State_Text;
        public Button button_Play;
        public Button button_Pause;

        private void OnEnable()
        {
            button_Play.onClick.AddListener(ClickOnPlayButton);
            button_Pause.onClick.AddListener(ClickOnPauseButton);
        }

        private void ClickOnPauseButton()
        {
            OnPauseButton?.Invoke(this);
        }

        private void ClickOnPlayButton()
        {
            OnMenuComplete?.Invoke(this);
        }

        public void Init(string stateName)
        {
            State_Text.text = stateName;
        }

        private void OnDisable()
        {
            button_Play.onClick.RemoveListener(ClickOnPlayButton);
            button_Pause.onClick.RemoveListener(ClickOnPauseButton);
        }

    }
}