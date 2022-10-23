using UnityEngine;

namespace Assets.Scripts.Datas
{

    [System.Serializable]
    public class MovementStates
    {
        [SerializeField] private LayerMask _layersGrounds;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _radiusCheking;

        [SerializeField] private bool _facingRight = false;

        public float Speed { get => _speed; private set => _speed = value; }
        public float JumpForce { get => _jumpForce; private set => _jumpForce = value; }
        public bool isRight { get => _facingRight; private set => _facingRight = value; }

        public bool IsGrounds(Transform transform) => Physics2D.OverlapCircle(transform.position, _radiusCheking, _layersGrounds);

        public void ChangeDirection(Transform transform)
        {
            _facingRight = !_facingRight;
            transform.Rotate(0, 180, 0);
        }
    }
}