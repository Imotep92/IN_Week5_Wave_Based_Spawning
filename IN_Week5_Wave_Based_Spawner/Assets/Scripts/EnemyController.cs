using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody enemyRb;
    private GameObject player;

    public float yLimit = 1f;

    //GameObject Brute;
    //GameObject Speedster;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        //Brute = GameObject.Find("Enemy_Brute");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y > 2.5)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        }
        
        if (transform.position.y < -5)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().score++;
            Destroy(gameObject);
        }

        //enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);  OLD

    }
}
