using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameStateMachine
{
    public class PlayState : MonoBehaviour
    {

        public UnityAction<PlayState> OnPlayStateComplete;

        public TextMesh State_text;

        public Transform ObjectForMove;
        public Transform Object_B;
        private bool isGameWin;
        private float speed = 5;

        public bool IsGameWinPlayState { get => isGameWin; set => isGameWin = value; }

        public void Init(string StateName)
        {
            State_text.text = StateName;
            _ = StartCoroutine("CoMoveObject");
        }

        private IEnumerator CoMoveObject()
        {
            while (true)
            {
                //float dist = Vector3.Distance(ObjectForMove.position, Object_B.position);
                float step = speed * Time.deltaTime;
                ObjectForMove.Translate(Object_B.position * step);
                if (ObjectForMove.position.x >= Object_B.position.x)
                {
                    IsGameWinPlayState = true;
                    OnPlayStateComplete?.Invoke(this);
                    StopCoroutine(nameof(CoMoveObject));
                    break;
                }
                yield return null;
            }
        }
    }
}