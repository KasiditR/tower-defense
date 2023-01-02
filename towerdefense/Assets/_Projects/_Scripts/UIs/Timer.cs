using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;
namespace Towerdefense
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private TMP_Text _timeCountText;
        [SerializeField] private int _duration;
        [SerializeField] private Gradient _gradient;
        private int _remainingDuration;
        public event Action onTimerEnd;
        public void PlayTime()
        {
            Being(_duration);
        }
        private void Being(int second)
        {
            _remainingDuration = second;
            StartTimer();
        }
        private void StartTimer()
        {
            _fill.fillAmount = 1;
            StartCoroutine(TimerCoroutine());
        }
        private IEnumerator TimerCoroutine()
        {
            _fill.DOFillAmount(0,_duration).SetEase(Ease.Linear);
            while (_remainingDuration >= 0)
            {
                _timeCountText.text = $"{_remainingDuration / 60:00} : {_remainingDuration % 60:00}";
                _fill.color = _gradient.Evaluate(_fill.fillAmount);
                _remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            OnEnd();
        }

        private void OnEnd()
        {
            onTimerEnd?.Invoke();
        }
    }
}
