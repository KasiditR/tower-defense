using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Towerdefense
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fillHealthBar;
        [SerializeField] private float _speedSeconds;
        private void Start()
        {
            this.GetComponentInParent<Health>().onHealthChanged += OnHealthChange;
        }
        private void LateUpdate()
        {
            this.transform.LookAt(Camera.main.transform);
            this.transform.Rotate(new Vector3(0,180,0));
        }
        private void OnHealthChange(float value)
        {
            StartCoroutine(ChangeHealthCoroutine(value));
        }
        private IEnumerator ChangeHealthCoroutine(float value)
        {
            float preChangePct = _fillHealthBar.fillAmount;
            float elapsed = 0;
            while (elapsed < _speedSeconds)
            {
                elapsed += Time.deltaTime;
                _fillHealthBar.fillAmount = Mathf.Lerp(preChangePct,value,elapsed / _speedSeconds);
                yield return null;
            }
            _fillHealthBar.fillAmount = value;
        }
        
    }
}
