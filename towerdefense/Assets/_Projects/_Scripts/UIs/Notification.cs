using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
namespace Towerdefense
{
    public class Notification : MonoBehaviour
    {
        [Header("Animation Prop")]
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Vector2 _endValue;
        [SerializeField] private float _duration;
        [SerializeField] private float _delayTime;
        [SerializeField] private Ease _ease;
        [Space]
        [SerializeField] private TMP_Text _notificationText;
        private Vector2 _startPosition;
        private Tween _tweenNotification;
        private void Awake()
        {
            _startPosition = _rectTransform.anchoredPosition;
        }
        public void SendNotification(string massage)
        {
            _notificationText.text = $"{massage}";
            _tweenNotification.Kill();
            _tweenNotification = _rectTransform.DOAnchorPos(_endValue,_duration,false).SetEase(_ease).OnComplete(() => 
            {
                _rectTransform.DOAnchorPos(_startPosition,_duration,false).SetDelay(_delayTime).SetEase(_ease);
            });
        }
    }
}
