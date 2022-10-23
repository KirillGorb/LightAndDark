using UnityEngine;

public class SlizePlatform : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rd))
        {
            rd.velocity = Vector2.zero;
        }
    }
}