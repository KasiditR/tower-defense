using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;
using TMPro;
namespace Towerdefense
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private Notification _notification;
        [SerializeField] private WaveSO _waveSO;
        [SerializeField] private Timer _timer;
        private bool _isPrepared;
        private GameBaseState _currentState;
        public WaveSO WaveSO { get => _waveSO;}
        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            Instance = this;
        }
        private void Start()
        {
            StartCoroutine(StartGameCoroutine());
        }
        private IEnumerator StartGameCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            _timer.PlayTime();
            _waveSO.WaveCount = 0;
            _currentState = new PrepareState();
            _currentState.EnterState(this);
        }
        private void Update()
        {
            if (_currentState != null)
            {
                _currentState.ExecuteState(this);
            }
        }
        public void SwitchState(GameBaseState state)
        {
            _currentState.ExitState(this);
            _currentState = state;
            state.EnterState(this);
        }
        public void SendNotification(string massage)
        {
            _notification.SendNotification(massage);
        }
        public bool GetIsPrepared()
        {
            return _isPrepared;
        }
        public void SetIsPrepared(bool value)
        {
            _isPrepared = value;
        }
    }
}
