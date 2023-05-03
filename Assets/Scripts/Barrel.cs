using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Barrel : MonoBehaviour
{
    [SerializeField] private Barrels barrel;
    private SpriteRenderer sprite;
    private string boomTag;
    private float radius;
    private int damage;
    private Player player;
    private ObjectPooler objectPooler;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = barrel.sprite;
        radius = barrel.radius;
        damage = barrel.damage;
        boomTag = barrel.tag;
        player = Player.instance;
        objectPooler = ObjectPooler.instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            objectPooler.SpawnFromPool(boomTag, transform.position, transform.rotation);
            
            if (Vector2.Distance(transform.position, player.transform.position) < radius)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
