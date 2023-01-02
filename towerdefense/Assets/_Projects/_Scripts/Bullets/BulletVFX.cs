using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Towerdefense
{
    public class BulletVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _projectile;
        [SerializeField] private ParticleSystem _hit;
        private Transform _target;
        private float _duration;
        public void InitBulletVFX(Transform target,float duration)
        {
            _target = target;
            _duration = duration;
            MoveToObject();
        }
        private void MoveToObject()
        {
            _projectile.gameObject.SetActive(true);
            // _hit.gameObject.SetActive(false);

            Vector3 relativePos = _target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;

            this.transform.DOMove(_target.position, _duration, false).SetEase(Ease.Linear).OnComplete(() =>
            {
                _projectile.gameObject.SetActive(false);
                // _hit.gameObject.SetActive(true);
                _hit.Play();
                StartCoroutine(CloseBulletCoroutine());
            });
        }
        private IEnumerator CloseBulletCoroutine()
        {
            yield return new WaitForSeconds(0.1f);
            this.gameObject.SetActive(false);
            
        }
        
    }
}
