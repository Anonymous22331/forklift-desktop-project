using UnityEngine;

namespace Forklift
{
    public class ForkliftView : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform _forkliftObjectTransform;
        [SerializeField] private Rigidbody _rb;

        [Header("Fork")]
        [SerializeField] private Transform _forkObjectTransform;
        [SerializeField] private float _minForkHeight = 0.2f;
        [SerializeField] private float _maxForkHeight = 2f;
        
        public void ApplyMovement(float forwardSpeed)
        {
            Vector3 velocity = _forkliftObjectTransform.forward * forwardSpeed;
            _rb.linearVelocity = new Vector3(
                velocity.x,
                _rb.linearVelocity.y,
                velocity.z);
        }

        public void ApplyTurn(float turnSpeed)
        {
            Quaternion delta = Quaternion.Euler(
                0f,
                turnSpeed * Time.fixedDeltaTime,
                0f);

            _rb.MoveRotation(_rb.rotation * delta);
        }

        public void MoveFork(float delta)
        {
            Vector3 pos = _forkObjectTransform.localPosition;
            pos.y = Mathf.Clamp(pos.y + delta, _minForkHeight, _maxForkHeight);
            _forkObjectTransform.localPosition = pos;
        }
    }
}