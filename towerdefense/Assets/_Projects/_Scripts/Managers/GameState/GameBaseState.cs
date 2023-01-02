using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public abstract class GameBaseState
    {
        public abstract void EnterState(GameManager gameManager);
        public abstract void ExecuteState(GameManager gameManager);
        public abstract void ExitState(GameManager gameManager);
    }
}
