using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class DetectionActivation : MonoBehaviour
{
    [SerializeField] private List<MyClass> _system;

    [Serializable]
    public class MyClass
    {
        [SerializeField] public Collision IsCollition;

        [SerializeField] public UnityEvent _triggerEvent;

        [SerializeField] private bool _isTag;
        [SerializeField] private string _tag;

        public bool SetProf(string tags) => (_isTag && _tag == tags) || !_isTag;
    }

    private void CollisionInvoke(Collision d, string tag)
    {
        for (int i = 0; i < _system.Count; i++)
        {
            if (_system[i].IsCollition == d && _system[i].SetProf(tag))
            {
                _system[i]._triggerEvent?.Invoke();
            }
        }
    }

    private void Awake()
    {
        CollisionInvoke(Collision.Awake, "");
    }

    private void Start()
    {
        CollisionInvoke(Collision.Start, "");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollisionInvoke(Collision.TriggerEnter2D, other.gameObject.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CollisionInvoke(Collision.TriggerExit2D, other.gameObject.tag);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CollisionInvoke(Collision.TriggerStay2D, other.gameObject.tag);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CollisionInvoke(Collision.ColliderEnter2D, other.gameObject.tag);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        CollisionInvoke(Collision.ColliderExit2D, other.gameObject.tag);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        CollisionInvoke(Collision.ColliderStay2D, other.gameObject.tag);
    }
}

public enum Collision
{
    Start = 0,
    TriggerEnter2D = 1,
    TriggerExit2D = 2,
    TriggerStay2D = 3,
    ColliderEnter2D = 4,
    ColliderExit2D = 5,
    ColliderStay2D = 6,
    Awake = 7
}