using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Towerdefense
{
    public class GameOverState : GameBaseState
    {
        // private GameUI _gameUI;
        public static event Action onGameOver;
        public override void EnterState(GameManager gameManager)
        {
            onGameOver?.Invoke();
            // _gameUI = GameUI.Instance;
            // _gameUI?.OpenGameOverPanel();
        }

        public override void ExecuteState(GameManager gameManager)
        {
        }

        public override void ExitState(GameManager gameManager)
        {
        }
    }
}
