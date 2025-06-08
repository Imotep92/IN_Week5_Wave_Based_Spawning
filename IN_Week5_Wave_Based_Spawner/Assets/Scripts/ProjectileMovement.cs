using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;


public class ProjectileMovement : MonoBehaviour
{
    
    public float speed;
    Rigidbody bulletProjectileRb;
    private float rocketImpactStrength = 150f;
    private GameObject enemy;

    void Start()
    {
        bulletProjectileRb = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        Vector3 lookDirection = (enemy.transform.position - transform.position).normalized;

        bulletProjectileRb.AddForce(lookDirection * speed);

    }

    //Rocket projectile on collision hit "enemy effect
    
    private void OnCollisionEnter(Collision collision)
         {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromBullet = (collision.gameObject.transform.position - transform.position).normalized;

                Debug.Log("Bullet has collided with " + collision.gameObject.name);
                enemyRb.AddForce(awayFromBullet * rocketImpactStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
            else if(collision.gameObject.CompareTag("walls"))
            {
                Destroy(gameObject);
            }
         }

    
    
    /*EXAMPLE*/
}
