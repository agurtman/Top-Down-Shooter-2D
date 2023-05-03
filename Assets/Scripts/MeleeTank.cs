using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float distance = 10f;
    private Player target;
    private float timer;
    private float hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        target = Player.instance;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null && timer <= 0)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            timer = hitCooldown;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            if (timer <= 0 && Vector2.Distance(transform.position, target.transform.position) < distance)
            {
                Move();
                SetAngle(target.transform.position);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
