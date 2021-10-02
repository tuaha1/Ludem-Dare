using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 1000;
    [SerializeField] int currentHealth;
    [SerializeField] ParticleSystem mainGas;
    AudioSource audioPlayer;

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

        if (Input.GetKey(KeyCode.Space))
        {
            HandleAudio();
            mainGas.Play();
            TakeDamage(damageRate);
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * Thrust);
        }

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

}
