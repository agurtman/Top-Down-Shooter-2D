using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [Header("Общие характеристики")]
    [Range(5, 100)]
    [SerializeField] protected int maxHealth = 100;
    [Range(0f, 5f)]
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected float angleOffset = 90f;
    [Tooltip("Скорость поворота")]
    [SerializeField] protected float rotationSpeed = 7f;
    [Space(10)]
    [SerializeField] private int points = 0;
    protected Rigidbody2D rb;
    protected int currentHealth;
    protected UI ui;
    protected ObjectPooler objectPooler;
    [SerializeField] private string hpTag;
    [SerializeField] protected string tracks;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        objectPooler = ObjectPooler.instance;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Stats.Score += points;
            ui.UdateScoreAndLevel();
            Destroy(gameObject);
            objectPooler.SpawnFromPool(hpTag, transform.position, transform.rotation);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        objectPooler.SpawnFromPool(tracks, transform.position, transform.rotation);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0f, angleZ + angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * rotationSpeed);
    }
}
