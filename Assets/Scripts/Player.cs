using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    private float timer;
    private int heal;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ui.UpdateHP(currentHealth);

        if (currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ChangeHealth(int count)
    {
        currentHealth += count;
        ui.UpdateHP(currentHealth);
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime);
        objectPooler.SpawnFromPool(tracks, transform.position, transform.rotation);
    }

    private void Update()
    {
        Move();

        if (timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                timer = reloadTime;
            }
        }
        else timer -= Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HP") && currentHealth < maxHealth)
        {
            heal = Random.Range(1, 10);
            ChangeHealth(heal);
            other.gameObject.SetActive(false);

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
                ui.UpdateHP(currentHealth);
            }
        }
    }

    public void UpgradeGun()
    {
        if (this.reloadTime > 0.1f)
            this.reloadTime -= 0.1f;
    }
}
