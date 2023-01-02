using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class ExplosionBullet : MonoBehaviour
    {
        [SerializeField] private float _radius = 1;
        [SerializeField] private LayerMask _layerMask;
        private Collider[] _colliders;
        private float _damage;
        private CharacterType _characterType;
        private BaseEnemyCharacter _baseEnemyCharacter;
        public void InitDamage(float damage,CharacterType characterType)
        {
            this._damage = damage;
            this._characterType = characterType;
        }
        private void OnEnable()
        {
            Explosion();
        }

        private void Explosion()
        {
            StartCoroutine(CloseExplosionCoroutine());
            _colliders = Physics.OverlapSphere(this.transform.position, _radius + 0.5f, _layerMask);
            foreach (Collider item in _colliders)
            {
                if (item.TryGetComponent<BaseEnemyCharacter>(out _baseEnemyCharacter))
                {
                    float resultDamage = this._damage;
                    if (_baseEnemyCharacter.characterType == this._characterType)
                    {
                        resultDamage *= 2;
                    }

                    IDamageable damageable = item.GetComponent<IDamageable>();
                    damageable.TakeDamage(resultDamage);
                }
            }
        }

        private IEnumerator CloseExplosionCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            this.gameObject.SetActive(false);
        }
        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,_radius +0.5f);
        }
    }
}
