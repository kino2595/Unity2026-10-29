using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        transform.Translate(
         Vector3.right * speed * Time.deltaTime
         );

        if (transform.position.x > 12f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}