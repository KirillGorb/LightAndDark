using UnityEngine;
using Assets.Scripts.Datas;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    class MovePlayer : MonoBehaviour
    {
        [SerializeField] private MovementStates _moveDataPlayer;

        private Rigidbody2D _rigidbody2D;

        private float _moveInput => Input.GetAxis("Horizontal");

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();


            startGravity = _rigidbody2D.gravityScale;
        }

        private void Update()
        {
            MoveRight();
            Flip();
            Jump();
        }
        [SerializeField] private float startGravity;
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Effector"))
            {
                _rigidbody2D.gravityScale = 0;
                _rigidbody2D.velocity = Vector2.zero;
            }
            if (other.gameObject.CompareTag("Effector") && Input.GetKey(KeyCode.W))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _moveDataPlayer.JumpForce * Time.fixedDeltaTime);
            }
            if (other.gameObject.CompareTag("Effector") && Input.GetKey(KeyCode.S))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -_moveDataPlayer.JumpForce * Time.fixedDeltaTime);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Effector"))
            {
                _rigidbody2D.gravityScale = startGravity;
            }
        }

        private void MoveRight()
        {
            if (_moveInput != 0)
                _rigidbody2D.velocity = new Vector2(_moveInput * _moveDataPlayer.Speed, _rigidbody2D.velocity.y);
            else
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }

        private void Jump()
        {
            if (_moveDataPlayer.IsGrounds(transform) && Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _moveDataPlayer.JumpForce * Time.fixedDeltaTime);
            }
        }

        private void Flip()
        {
            if ((_moveDataPlayer.isRight && _moveInput > 0) || (!_moveDataPlayer.isRight && _moveInput < 0))
                _moveDataPlayer.ChangeDirection(transform);
        }
    }
}
