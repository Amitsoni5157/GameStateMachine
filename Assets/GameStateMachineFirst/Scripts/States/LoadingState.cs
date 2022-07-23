using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameStateMachine
{
    public class LoadingState : MonoBehaviour
    {
        public UnityAction<LoadingState> OnLoadingComplete;

        public TextMesh State_Text;

        public void Init(string stateName)
        {
            State_Text.text = stateName;
            StartCoroutine("Co_WaitForEndLoadingScreen");
        }

        private IEnumerator Co_WaitForEndLoadingScreen()
        {
            yield return new WaitForSeconds(3);
            OnLoadingComplete?.Invoke(this);
            StopCoroutine("Co_WaitForEndLoadingScreen");
        }
    }
}