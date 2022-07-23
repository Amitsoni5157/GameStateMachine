using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace GameStateMachine
{
    public class PauseState : MonoBehaviour
    {
        public UnityAction<PauseState> OnPauseComplete;
        public TextMesh State_Text;
        public Button button_Play;

        private void OnEnable()
        {
            button_Play.onClick.AddListener(ClickOnRePlayButton);
        }

        private void ClickOnRePlayButton()
        {
            OnPauseComplete?.Invoke(this);
        }

        public void Init(string stateName)
        {
            State_Text.text = stateName;
        }

        private void OnDisable()
        {
            button_Play.onClick.RemoveListener(ClickOnRePlayButton);
        }
    }
}