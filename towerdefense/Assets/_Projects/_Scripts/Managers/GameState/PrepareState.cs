using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Towerdefense
{
    public class PrepareState : GameBaseState
    {
        private BuildManager _buildManager;
        public static event Action onPrepared;
        public override void EnterState(GameManager gameManager)
        {
            onPrepared?.Invoke();
            _buildManager = BuildManager.Instance;
            gameManager.SendNotification("Preparing Your Turret");
        }

        public override void ExecuteState(GameManager gameManager)
        {
            if (gameManager.GetIsPrepared())
            {
                Debug.Log("Change State");
                _buildManager.SetKeyBuild(string.Empty);
                gameManager.SwitchState(new WaveState());
            }
        }

        public override void ExitState(GameManager gameManager)
        {
            gameManager.SetIsPrepared(false);
        }
    }
}
