using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Towerdefense.Menu
{
    public class ButtonAnimation : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private RectTransform _rect;
        [SerializeField] private Vector3 _endValue;
        [SerializeField] private float _duration = 0.2f;
        [SerializeField] private Ease _ease = Ease.Linear;
        private Vector3 _startPosition;
        private Tween _hoverTween;
        private void Start()
        {
            _startPosition = _rect.anchoredPosition3D;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            _hoverTween = _rect.DOAnchorPos3D(_endValue,_duration,false).SetEase(_ease);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            _hoverTween.Kill();
            _rect.DOAnchorPos3D(_startPosition,_duration,false).SetEase(_ease);
        }
    }
}
