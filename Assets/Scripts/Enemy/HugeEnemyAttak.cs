using System.Collections;
using UnityEngine;

public class HugeEnemyAttak : MonoBehaviour
{
    [SerializeField] private float _timerAttack;
    [SerializeField] private float _offset;

    [SerializeField] private GameObject _enemyAttackObj;

    private GameObject _player;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(SpawnAttak());
    }

    private Vector3 PlayerPos => _player.transform.position - transform.position;
    private float Angel => Mathf.Atan2(PlayerPos.y, PlayerPos.x) * Mathf.Rad2Deg;
    IEnumerator SpawnAttak()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timerAttack);
            Instantiate(_enemyAttackObj, transform.position, Quaternion.Euler(0, 0, Angel + _offset));
        }
    }
}