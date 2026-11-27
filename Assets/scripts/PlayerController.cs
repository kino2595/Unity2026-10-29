using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float blinkDuration = 2f;
    public float blinkInterval = 0.2f;

    private bool isBlinking = false;
    private SpriteRenderer spriterenderer;

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, y, 0).normalized;

        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
                );
        }
    }

    IEnumerator Blink()
    {
        isBlinking = true;

        float timer = 0f;

        while (timer < blinkDuration)
        {
            spriterenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);

            spriterenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);

            timer += blinkInterval * 2;
        }

        spriterenderer.enabled = true;
        isBlinking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")&&!isBlinking)
        {
            Debug.Log("“G‚É“–‚½‚Á‚½I");
            StartCoroutine(Blink());
        }
    }
}