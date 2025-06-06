using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;

    public float xRange, zRange = 25f;
   

    public GameObject Respawn_Pad;

    // public int waveNumber = 1;   USE

    // private int enemyCount;   USE

    /* Start is called once before the first execution of 
    Update after the MonoBehaviour is created */
    void Start()
    {
        SpawnEnemyWave();  //spawn enemy upon start of game
          
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
             randomSpawnPosition(0), Quaternion.identity);
        } 
             
             
    }

    // Update is called once per frame
    void Update()
    {

        /*  CODE TO USE
        
        enemyCount = fFindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length
        if(enemycount == 0)
        {
         wavenumber ++
         SpawnEnemyWave(waveNumber);
         //SpawnPowerUps() 


         //modulus
         if（waveNumber % 5 == 0)
         {
            //spawn a miniboss

         }
        
        } */


        /*  OLD CODE
        if(Input.GetKeyDown(KeyCode.Space)) //instantiate enemyPrefab upon pressing 'spacebar'
          {
              Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],
               randomSpawnPosition(0), Quaternion.identity);
          }*/

    }

    private Vector3 randomSpawnPosition(float yPosition) //randomSpawnPosition return method for enemyPrefab
    {
        float randomXPosition = Random.Range(-xRange, xRange);
        float randomZPosition = Random.Range(-zRange, zRange);

        Vector3 randomPos = new Vector3(randomXPosition, yPosition, randomZPosition);

        return randomPos;


        /* 
        
        float randomXPosition = Random.Range(-xRange, xRange);
        float randomZPosition = Random.Range(-zRange, zRange);

        Vector3 randomPos = new Vector3(randomXPosition, yPosition, randomZPosition);

        return randomPos;
        
        
        */
    }
    

}
