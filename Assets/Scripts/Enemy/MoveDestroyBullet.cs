using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveDestroyBullet : MonoBehaviour
{
    [SerializeField] private float _speedRight;
    [SerializeField] private float _timeLive;

    private Rigidbody2D _rd;

    private void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
        _rd.AddRelativeForce(-Vector2.up * _speedRight);
        Destroy(gameObject, _timeLive);
    }
}