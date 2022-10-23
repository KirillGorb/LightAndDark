using UnityEngine;

public class JumperPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rd))
        {
            rd.velocity = -rd.velocity;
        }
    }
}