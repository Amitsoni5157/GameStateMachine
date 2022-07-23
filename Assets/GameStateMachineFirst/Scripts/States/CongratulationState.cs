using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameStateMachine
{
    public class CongratulationState : MonoBehaviour
    {
        public UnityAction<CongratulationState> OnCompleteCongrats;
        public TextMesh State_Text;


        public void Init(string stateName)
        {
            State_Text.text = stateName;
            StartCoroutine("Co_WaitForEndSplashState");
        }

        private IEnumerator Co_WaitForEndSplashState()
        {
            yield return new WaitForSeconds(2);
            OnCompleteCongrats?.Invoke(this);
            StopCoroutine("Co_WaitForEndSplashState");


        }
    }
}