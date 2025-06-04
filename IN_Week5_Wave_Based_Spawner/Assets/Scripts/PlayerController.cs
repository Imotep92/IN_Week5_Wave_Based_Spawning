using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;

    public GameObject focalPoint;

    public bool hasPowerup;

    private float powerupStrength = 20f;

    public GameObject powerupIndicator;

    //playerRespawn and player lower boundary y axis

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal_Point");
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
