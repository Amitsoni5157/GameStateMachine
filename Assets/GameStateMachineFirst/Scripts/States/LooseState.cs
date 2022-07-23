using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameStateMachine
{
    public class LooseState : MonoBehaviour
    {
        public UnityAction<LooseState> OnCompleteLoose;
        public TextMesh State_Text;


        public void Init(string stateName)
        {
            State_Text.text = stateName;
            StartCoroutine("Co_WaitForEndLooseState");
        }

        private IEnumerator Co_WaitForEndLooseState()
        {
            yield return new WaitForSeconds(3);
            OnCompleteLoose?.Invoke(this);
            StopCoroutine("Co_WaitForEndLooseState");


        }
    }
}