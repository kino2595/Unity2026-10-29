using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnInterval = 2f;

    public float spawnX = 10f;
    public float minY = -4f;
    public float maxY = 4f;

    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >=spawnInterval)
        {
            SpawnEnemy(); 
            timer =0f;
        }
    }
    void SpawnEnemy()
    {
        float randomY =Random.Range(minY,maxY);

        Vector3 spawnPosition = new Vector3(
            spawnX,
            randomY,
            0f
            );

        GameObject enemy =Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
            );

        EnemyController controller =
            enemy.GetComponent<EnemyController>();

        controller.moveSpeed = Random.Range(minSpeed,maxSpeed);
    }
}
