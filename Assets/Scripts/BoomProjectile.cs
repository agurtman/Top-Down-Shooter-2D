using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomProjectile : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
