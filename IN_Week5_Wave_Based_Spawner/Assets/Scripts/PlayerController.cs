using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;

    public GameObject focalPoint;

    public bool hasPowerup;

    private float powerupStrength = 20f;

    public GameObject powerupIndicator;

    public GameObject game_Over_Panel;

    private Vector3 startPosition;

    public int lives = 3;

    //playerRespawn and player lower boundary y axis

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        focalPoint.transform.position = transform.position;

        playerRb.AddForce((focalPoint.transform.forward * moveDirection.y + focalPoint.transform.right * moveDirection.x) * speed);

        powerupIndicator.SetActive(hasPowerup);
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.6f, 0);
        powerupIndicator.transform.Rotate(Vector3.up * Time.deltaTime);

       if (transform.position.y < -3)
        {
            transform.position = startPosition;
            playerRb.linearVelocity = Vector3.zero;
            lives--;
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(0); //bring up main menu (will bring up game over in future)
        } 
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);

            //Debug.Log("has power up ");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.transform.position - transform.position).normalized;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            Debug.Log("This player has collided with " + collision.gameObject.name);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
    }


}
