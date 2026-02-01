using DG.Tweening;
using UnityEngine;

namespace Cargo
{
    public class CargoView : MonoBehaviour
    {
        [SerializeField] private GameObject _cargoPrefab;

        private Rigidbody _instanceRigidbody;
        private Transform _instanceTransform;

        private const float _animationPositionOffset = 5f;
        private const float _animationRotationOffset = 360f;
        
        public void Spawn(Vector3 targetPosition, float duration)
        {
            var instance = Instantiate(_cargoPrefab);
            _instanceTransform = instance.transform;
            _instanceRigidbody = instance.GetComponent<Rigidbody>();

            _instanceRigidbody.isKinematic = true;

            _instanceTransform.position = targetPosition + Vector3.up * _animationPositionOffset;
            _instanceTransform.rotation = Quaternion.identity;

            _instanceTransform
                .DOMove(targetPosition, duration)
                .SetEase(Ease.OutQuad);

            _instanceTransform
                .DORotate(Vector3.up * _animationRotationOffset, duration, RotateMode.FastBeyond360)
                .OnComplete(EnablePhysics);
        }

        public void PlayDeliveryAnimation(float duration)
        {
            if (_instanceRigidbody == null)
                return;

            _instanceRigidbody.isKinematic = true;

            _instanceTransform
                .DOMoveY(_instanceTransform.position.y + _animationPositionOffset, duration)
                .SetEase(Ease.InQuad);

            _instanceTransform
                .DORotate(Vector3.up * _animationRotationOffset, duration, RotateMode.FastBeyond360)
                .OnComplete(() =>
                {
                    _instanceTransform.gameObject.SetActive(false);
                });
        }

        private void EnablePhysics()
        {
            _instanceRigidbody.isKinematic = false;
        }
    }
}