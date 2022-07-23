using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameStateMachine
{
    public class NextLevelState : MonoBehaviour
    {
        public UnityAction<NextLevelState> OnCompleteNectLevel;
        public TextMesh State_Text;


        public void Init(string stateName)
        {
            State_Text.text = stateName;
            _ = StartCoroutine(nameof(Co_WaitForEndNectState));
        }

        private IEnumerator Co_WaitForEndNectState()
        {
            yield return new WaitForSeconds(3);
            OnCompleteNectLevel?.Invoke(this);
            StopCoroutine(nameof(Co_WaitForEndNectState));


        }
    }
}