using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 1000;
    [SerializeField] int currentHealth;
<<<<<<< Updated upstream
    [SerializeField] ParticleSystem mainGas;
    AudioSource audioPlayer;
=======
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftGas;
    [SerializeField] ParticleSystem rightGas;
    [SerializeField] ParticleSystem successGas;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip fuelSound;

    AudioSource audioSource;
>>>>>>> Stashed changes

    int damageRate = 1;
    Rigidbody rb;
    public HealthBar healthBar;

    float Thrust = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Retry()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
<<<<<<< Updated upstream

        if (Input.GetKey(KeyCode.Space))
=======
        HandleThrust();
        HandleRotation();
        HandleHealth();
    }

    void HandleHealth()
    {
        if (currentHealth <= 0)
>>>>>>> Stashed changes
        {
            HandleAudio();
            mainGas.Play();
            TakeDamage(damageRate);
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * Thrust);
        }
<<<<<<< Updated upstream
=======

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
>>>>>>> Stashed changes

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

        if(currentHealth <= 0)
        {
            Retry();
        }

    }

    void HandleAudio()
    {
        if(!audioPlayer.isPlaying)
        {
            audioPlayer.Play();
        }
    }

    void TakeDamage(int Damage)
    {
        currentHealth = currentHealth - Damage;
        healthBar.SetHealth(currentHealth);
    }

<<<<<<< Updated upstream
}
=======
    private void OnCollisionEnter(Collision collision)
    {
        HandleFuelCollision(collision);
    }

    void HandleFuelCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            successGas.Play();
            currentHealth = currentHealth + 100;
            healthBar.SetHealth(currentHealth);            
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            currentHealth = currentHealth - 30;
            healthBar.SetHealth(currentHealth);
        }
    }

}
>>>>>>> Stashed changes
