using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private string _nameTriger = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.transform.tag == _nameTriger)
            {
                Destroy(gameObject);
            }
        }
    }
}
