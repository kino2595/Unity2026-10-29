using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    public float minY =-4f;
    public float maxY =4f;

    public float changeTime =2f;

    private float timer;
    private float targetY;

void Start()
    {
        targetY =Random.Range(minY,maxY);
    }

void Update()
    {
transform.Translate(
    Vector3.left*moveSpeed*Time.deltaTime
    );

    Vector3 targetPosition =new Vector3(
        transform.position.x,
        targetY,
        transform.position.z
        );

    transform.position=Vector3.MoveTowards(
        transform.position,
        targetPosition,
        moveSpeed*Time.deltaTime
        );

        timer += Time.deltaTime;

        if(timer>=changeTime)
        {
            targetY = Random.Range(minY,maxY);
            timer = 0f;
        }

        if(transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }    
}