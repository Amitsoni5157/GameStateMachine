using UnityEngine;
namespace GameStateMachine
{
    public abstract class BaseGameFlowState : MonoBehaviour
    {
        private bool isgameWin => IsGameWin;
        protected bool IsGameWin;

        private bool isgamePause => IsGamepause;
        protected bool IsGamepause;

        private bool isMenuSelectOnWin => IsMenuSelectOnWin;
        protected bool IsMenuSelectOnWin;


        #region Virtual Methods
        public virtual void GameLoadingStarted()
        {
            //To Do All Work Of GameLoadingStarted
        }


        public virtual void GameSplashStarted()
        {
            //To Do All Work Of Splash related
        }


        public virtual void GameMenuStarted()
        {
            //To Do All Work Of Menu related
        }

        public virtual void GamePlayStarted()
        {
            //To Do All Work Of GamePlay related
        }

        public virtual void GamePauseStarted()
        {
            //To Do All Work Of Pause related
        }

        public virtual void GameWinStarted()
        {
            //To Do All Work Of Win related
        }


        public virtual void GameLooseStarted()
        {
            //To Do All Work Of Loose related
        }

        public virtual void GameCongratulationStarted()
        {
            //To Do All Work Of Congratulation related
        }

        public virtual void GameNextLevelStarted()
        {
            //To Do All Work Of NextLevel related
        }
        #endregion
    }
}