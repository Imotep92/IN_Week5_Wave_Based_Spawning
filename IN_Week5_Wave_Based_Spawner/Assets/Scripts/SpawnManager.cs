using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;

    public float xRange = 10f;
    public float zRange = 12.5f;

    /* Start is called once before the first execution of 
    Update after the MonoBehaviour is created */
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //instantiate enemyPrefab upon pressing 'spacebar'
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
             randomSpawnPosition(0), Quaternion.identity);
        }

    }

    private Vector3 randomSpawnPosition(float yPosition) //randomSpawnPosition return method for enemyPrefab
    {
        float randomXPosition = Random.Range(-xRange, xRange);
        float randomZPosition = Random.Range(-zRange, zRange);

        Vector3 randomPos = new Vector3(randomXPosition, yPosition, randomZPosition);

        return randomPos;
    }
    

}
