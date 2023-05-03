using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5f;
    [SerializeField] private string myTag = "";
    [SerializeField] private string boomTag;
    protected ObjectPooler objectPooler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tank>() != null && collision.gameObject.tag != myTag)
        {
            collision.gameObject.GetComponent<Tank>().TakeDamage(damage);
        }

        if (collision.gameObject.tag != "HP")
        {
            objectPooler.SpawnFromPool(boomTag, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        objectPooler.SpawnFromPool(boomTag, transform.position, transform.rotation);
    }
}
