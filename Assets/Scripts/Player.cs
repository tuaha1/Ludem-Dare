using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 1000;
    [SerializeField] int currentHealth;
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftGas;
    [SerializeField] ParticleSystem rightGas;

    [SerializeField] AudioClip mainEngine;

    AudioSource audioSource;

    int damageRate = 1;
    Rigidbody rb;
    public HealthBar healthBar;

    float Thrust = 10f;
    float sideThrust = 150f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Retry()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        HandleThrust();
        HandleRotation();

        if(currentHealth <= 0)
        {
            Retry();
        }
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            rightGas.Stop();
        }

        if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            leftGas.Stop();
        }

    }

    void RotateLeft()
    {
        StartRotation(Vector3.forward);
        if(!rightGas.isPlaying)
        {
            rightGas.Play();
        }

    }

    void RotateRight()
    {
        StartRotation(-Vector3.forward);
        if(!leftGas.isPlaying)
        {
            leftGas.Play();
        }

    }

    void StartRotation(Vector3 value)
    {
        transform.Rotate(value * Time.deltaTime * sideThrust);
    }

    void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * Thrust);
        TakeDamage(damageRate);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    void TakeDamage(int Damage)
    {
        currentHealth = currentHealth - Damage;
        healthBar.SetHealth(currentHealth);
    }

}