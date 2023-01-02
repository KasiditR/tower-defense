using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
namespace Towerdefense
{
    public class ShopItem : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [Header("Animation Prop")]
        [SerializeField] private RectTransform _rect;
        [SerializeField] private Vector2 _endValue;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [Space]
        [SerializeField] private string _tagTurret;
        [SerializeField] private Button _shopButton;
        private Vector2 _startSize;
        private BuildManager _buildManager;
        private Tween _hoverTween;
        public static event Action onShopTurret;
        private void OnValidate() 
        {
            if (_rect == null)
            {
                _rect = this.GetComponent<RectTransform>();
            }
        }
        private void Start()
        {
            _buildManager = BuildManager.Instance;
            _startSize = _rect.sizeDelta;
        }
        private void OnEnable() 
        {
            _shopButton.onClick.AddListener(() => ShopOnClick());
        }
        private void OnDisable()
        {
            _shopButton.onClick.RemoveListener(() => ShopOnClick());
        }
        public void ShopOnClick()
        {
            _buildManager.SetKeyBuild(_tagTurret);
            onShopTurret?.Invoke();
        }
        public void SetInteract(bool value)
        {
            _shopButton.interactable = value;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            HoverShop();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            PrimaryShop();
        }

        private void PrimaryShop()
        {
            _hoverTween.Kill();
            _rect.DOSizeDelta(_startSize, _duration, false).SetEase(_ease);
        }

        private void HoverShop()
        {
            _hoverTween = _rect.DOSizeDelta(_endValue, _duration, false).SetEase(_ease);
        }
    }
}
