using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public float xRange, zRange = 25f;
    public float excludeMinX, excludeMaxX = 5f;
    public float excludeMinZ, excludeMaxZ = 25f;
    public int waveNumber = 1;
    private int enemyCount;

    public GameObject[] powerupPrefab;

    public GameObject player;

    //public GameObject Respawn_Pad;



    /* Start is called once before the first execution of 
    Update after the MonoBehaviour is created */
    void Start()
    {
        SpawnEnemyWave(waveNumber);  //spawn enemy upon start of game
        SpawnPowerUps(0);

    }

    void SpawnEnemyWave(int enemiesTospawn)
    {
        for (int i = 0; i < enemiesTospawn; i++)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
             randomSpawnPosition(0), Quaternion.identity);
        }
    }

    void SpawnPowerUps(int powerupsToSpawn)
    {
        Instantiate(powerupPrefab[Random.Range(0, powerupPrefab.Length)],
        randomSpawnPoint(0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUps(waveNumber);
        }
        /* 
        //modulus
        if（waveNumber % 5 == 0)
        {
           //spawn a miniboss

        }
       } */
    }
    #region Enemy spawn position
    private Vector3 randomSpawnPosition(float yPosition) //randomSpawnPosition return method for enemyPrefab
    {

        float randomXPosition = GetRandomExcludingRange(-xRange, xRange, excludeMinX, excludeMaxX);
        float randomZPosition = GetRandomExcludingRange(-zRange, zRange, excludeMinZ, excludeMaxZ);

        Vector3 randomPos = new Vector3(randomXPosition, yPosition, randomZPosition);

        return randomPos;
    }

    float GetRandomExcludingRange(float min, float max, float excludeMin, float excludeMax)
    {
        float range1 = excludeMin - min;
        float range2 = max - excludeMax;
        float totalRange = range1 + range2;

        float rand = Random.Range(0f, totalRange);

        if (rand < range1)
        {
            return min + rand;
        }
        else
        {
            return excludeMax + (rand - range1);
        }
    }
    #endregion Enemy spawn position

    private Vector3 randomSpawnPoint(float yPosition)
    {
        float randomXPosition = Random.Range(-xRange, xRange);
        float randomZPosition = Random.Range(-zRange, zRange);

        Vector3 randomPos = new Vector3(randomXPosition, yPosition, randomZPosition);

        return randomPos;
    }

    void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
    }
}
