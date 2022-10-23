using UnityEngine;

class KolodActive : MonoBehaviour
{
    [SerializeField] private int _countBreak = 0;
    [SerializeField] private int _countBreakStoun = 3;
    [SerializeField] private int _maxBreak = 12;

    public void UnBreak(Animation anim)
    {
        anim.Play();
        _countBreak++;

        if (_countBreak % _countBreakStoun == 0)
            Destroy(anim.gameObject);

        if (_countBreak >= _maxBreak)
        {
            gameObject.SetActive(false);
        }
    }
}