using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    [Header("Стрельба")]
    [SerializeField] protected List<Transform> shootPoints;
    [SerializeField] protected float reloadTime = 0.5f;
    [SerializeField] protected string projectileTag;
    [SerializeField] protected AudioSource shootSound;


    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Shoot()
    {
        for(int i = 0; i < shootPoints.Count; i++)
        {
            if (i < 1)
                objectPooler.SpawnFromPool(projectileTag, shootPoints[i].position, shootPoints[i].rotation);
            else if (i < 2)
                StartCoroutine(DoubleShoot());
            else
                StartCoroutine(TripleShoot());

        }

        shootSound.Play();
        shootSound.pitch = Random.Range(0.9f, 1.1f);
    }

    IEnumerator DoubleShoot()
    {
        objectPooler.SpawnFromPool(projectileTag, shootPoints[0].position, shootPoints[0].rotation);
        yield return new WaitForSeconds(0.5f);
        objectPooler.SpawnFromPool(projectileTag, shootPoints[1].position, shootPoints[1].rotation);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator TripleShoot()
    {
        objectPooler.SpawnFromPool(projectileTag, shootPoints[0].position, shootPoints[0].rotation);
        yield return new WaitForSeconds(0.5f);
        objectPooler.SpawnFromPool(projectileTag, shootPoints[1].position, shootPoints[1].rotation);
        yield return new WaitForSeconds(0.5f);
        objectPooler.SpawnFromPool(projectileTag, shootPoints[2].position, shootPoints[2].rotation);
        yield return new WaitForSeconds(0.5f);
    }
}
