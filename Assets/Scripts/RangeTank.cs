using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float distanceToPlayer = 5f;
    private float timer;
    private Player target;

    protected override void Start()
    {
        base.Start();
        target = Player.instance;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < distanceToPlayer)
        {
            Move();
            if (timer <= 0)
            {
                Shoot();
                timer = reloadTime;
            }
            else timer -= Time.deltaTime;
        } 
        SetAngle(target.transform.position);
    }
}
