using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStateMachine
{
    public class GameManager : BaseGameFlowState
    {
        #region All State Prefab variable

        [Header("Loading State")]
        [SerializeField] private LoadingState _loadingState;
        [Header("Splash State")]
        [SerializeField] private SplashState _splashState;
        [Header("Menu State")]
        [SerializeField] private MenuState _menuState;
        [Header("Play State")]
        [SerializeField] private PlayState _playState;
        [Header("Pause State")]
        [SerializeField] private PauseState _pauseState;
        [Header("Win State")]
        [SerializeField] private WinState _winState;
        [Header("Congratulation State")]
        [SerializeField] private CongratulationState _congratsState;
        [Header("Next Level State")]
        [SerializeField] private NextLevelState _nextlevelstate;
        [Header("Loose State")]
        [SerializeField] private LooseState _looseState;

        #endregion

        private void Start()
        {
            SwitchState(GameState.Game_Loading);
        }

     //  //////////////////////////////////  SWITCH STATE WORK START FROM HERE /////////////////////////////////

        #region Switch State Work
        public void SwitchState(GameState switch_Gamestate)
        {
            switch (switch_Gamestate)
            {
                case GameState.Game_Loading:
                    GameLoadingStarted();
                    break;
                case GameState.Game_Splash:
                    GameSplashStarted();
                    break;
                case GameState.Game_Menu:
                    GameMenuStarted();
                    break;
                case GameState.Game_Play:
                    GamePlayStarted();
                    break;
                case GameState.Game_Pause:
                    GamePauseStarted();
                    break;
                case GameState.Game_Win:
                    GameWinStarted();
                    break;
                case GameState.Game_Loose:
                    GameLooseStarted();
                    break;
                case GameState.Game_Congratulation:
                    GameCongratulationStarted();
                    break;
                case GameState.Game_NextLevel:
                    GameNextLevelStarted();
                    break;
                default:
                    break;
            }
        }
        #endregion

        //  ///////////////////////////////  END STATE WORK START FROM HERE /////////////////////////////////////

        #region End State Work
        public void EndState(GameState end_GameState)
        {
            switch (end_GameState)
            {
                case GameState.Game_Loading:
                    SwitchState(GameState.Game_Splash);
                    break;
                case GameState.Game_Splash:
                    SwitchState(GameState.Game_Menu);
                    break;
                case GameState.Game_Menu:
                    SwitchState(GameState.Game_Play);
                    break;
                case GameState.Game_Play:
                    Debug.Log("game Win::"+IsGameWin);
                    if (IsGameWin)
                    {
                        SwitchState(GameState.Game_Win);
                    }
                    else
                    {
                        SwitchState(GameState.Game_Loose);
                    }
                    break;
                case GameState.Game_Pause:
                    SwitchState(GameState.Game_Menu);
                    break;
                case GameState.Game_Win:
                    if(IsMenuSelectOnWin)
                    {
                        SwitchState(GameState.Game_Menu);
                    }
                    else
                    {
                        SwitchState(GameState.Game_Congratulation);
                    }                    
                    break;
                case GameState.Game_Loose:
                    SwitchState(GameState.Game_Menu);
                    break;
                case GameState.Game_Congratulation:
                    SwitchState(GameState.Game_NextLevel);
                    break;
                case GameState.Game_NextLevel:
                    SwitchState(GameState.Game_Menu);
                    break;
            }
        }

        #endregion

        // ///////////////////////////////  LOADING WORK START FROM HERE /////////////////////////////////////////

        #region Loading State Start & End Work 
        public override void GameLoadingStarted()
        {
            base.GameLoadingStarted();
            LoadingState tempLoading = Instantiate(_loadingState);
            tempLoading.OnLoadingComplete += OnLoadingEnded;
            tempLoading.Init("Loading State");
        }
        private void OnLoadingEnded(LoadingState _obj)
        {
            Debug.Log("OnLoadingEnded");
            _obj.OnLoadingComplete -= OnLoadingEnded;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Loading);
        }
        #endregion

        //  //////////////////////////////  SPLASH WORK START FROM HERE //////////////////////////////////////////

        #region Splash State Start & End Work 
        public override void GameSplashStarted()
        {
            base.GameSplashStarted();
            SplashState tempSplash = Instantiate(_splashState);
            tempSplash.OnCompleteSplash += OnSplashEnded;
            tempSplash.Init("Splash State");
        }

        private void OnSplashEnded(SplashState _obj)
        {
            _obj.OnCompleteSplash -= OnSplashEnded;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Splash);
        }

        #endregion

        //  //////////////////////////////  GAME MENU WORK START FROM HERE ///////////////////////////////////////

        #region GameMenu State Start & End Work 
        public override void GameMenuStarted()
        {
            base.GameMenuStarted();
            MenuState tempMenu = Instantiate(_menuState);
            tempMenu.OnMenuComplete += OnMenuEnded;
            tempMenu.OnPauseButton += OnPauseClick;
            tempMenu.Init("menu State");
        }

        private void OnPauseClick(MenuState _obj)
        {
            _obj.OnMenuComplete -= OnMenuEnded;
            _obj.OnPauseButton -= OnPauseClick;
            Destroy(_obj.gameObject);
            SwitchState(GameState.Game_Pause);
        }

        private void OnMenuEnded(MenuState _obj)
        {
            _obj.OnMenuComplete -= OnMenuEnded;
            _obj.OnPauseButton -= OnPauseClick;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Menu);
        }
        #endregion

        //  ////////////////////////////////////  GAME PLAY WORK START FROM HERE /////////////////////////////////

        #region GamrPlay State Start & End Work 
        public override void GamePlayStarted()
        {
            base.GamePlayStarted();
            PlayState tempPlay = Instantiate(_playState);
            tempPlay.OnPlayStateComplete += OnPlayStateComplete;
            tempPlay.Init("Game Play State");
        }

        private void OnPlayStateComplete(PlayState _obj)
        {
            _obj.OnPlayStateComplete -= OnPlayStateComplete;
            IsGameWin = _obj.IsGameWinPlayState;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Play);
        }
        #endregion

        //  ////////////////////////////////////  PAUSE WORK START FROM HERE /////////////////////////////////////

        #region Pause State Start & End Work 
        public override void GamePauseStarted()
        {
            base.GamePauseStarted();
            PauseState tempPause = Instantiate(_pauseState);
            tempPause.OnPauseComplete += OnPauseStateComplete;
            tempPause.Init("Pause State");

        }

        private void OnPauseStateComplete(PauseState _obj)
        {
            _obj.OnPauseComplete -= OnPauseStateComplete;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Pause);            
        }

        #endregion

        //  ///////////////////////////////////  GAME WIN WORK START FROM HERE ///////////////////////////////////

        #region GameWin State Start & End Work 
        public override void GameWinStarted()
        {
            base.GameWinStarted();
            WinState tempWin = Instantiate(_winState);
            tempWin.OnClickMenuButton += OnClickMenuButton;
            tempWin.OnClickNectLevelButton += OnClickNextButton;
            tempWin.Init("Win State");
        }

        private void OnClickNextButton(WinState _obj)
        {
            _obj.OnClickMenuButton -= OnClickMenuButton;
            _obj.OnClickNectLevelButton -= OnClickNextButton;
            IsMenuSelectOnWin = false;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Win);

        }

        private void OnClickMenuButton(WinState _obj)
        {
            _obj.OnClickMenuButton -= OnClickMenuButton;
            _obj.OnClickNectLevelButton -= OnClickNextButton;
            IsMenuSelectOnWin = true;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Win);
            
        }
        #endregion

        //  //////////////////////////////////  GAME LOOSE WORK START FROM HERE ///////////////////////////////////

        #region GameLoose State Start & End Work 
        public override void GameLooseStarted()
        {
            LooseState temploose = Instantiate(_looseState);
            temploose.OnCompleteLoose += OnLooseEnd;
            temploose.Init("Loose State");
        }

        private void OnLooseEnd(LooseState _obj)
        {
            _obj.OnCompleteLoose -= OnLooseEnd;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Loose);
        }
        #endregion

        //  //////////////////////////////////  CONGRATULATION WORK START FROM HERE //////////////////////////////

        #region Congratulation State Start & End Work 
        public override void GameCongratulationStarted()
        {
            CongratulationState tempCongrts = Instantiate(_congratsState);
            tempCongrts.OnCompleteCongrats += OnCompleteCongrats;
            tempCongrts.Init("Congratulation State");
        }

        private void OnCompleteCongrats(CongratulationState _obj)
        {
            _obj.OnCompleteCongrats -= OnCompleteCongrats;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_Congratulation);
        }

        #endregion

        //  ///////////////////////////////////  NEXT LEVEL WORK START FROM HERE /////////////////////////////////

        #region GameNextLevel State Start & End Work 
        public override void GameNextLevelStarted()
        {
            NextLevelState tempnextLevel = Instantiate(_nextlevelstate);
            tempnextLevel.OnCompleteNectLevel += OnEndNextLevel;
            tempnextLevel.Init("Next level State");
        }

        private void OnEndNextLevel(NextLevelState _obj)
        {
            _obj.OnCompleteNectLevel -= OnEndNextLevel;
            Destroy(_obj.gameObject);
            EndState(GameState.Game_NextLevel);
        }
        #endregion
    }
}