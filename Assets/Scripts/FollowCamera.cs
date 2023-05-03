using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Player target;
    private Vector3 offset;

    void Start()
    {
        target = Player.instance;
        offset = transform.position - target.transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
        new Vector3(target.transform.position.x, target.transform.position.y) + offset, Time.deltaTime * 5);
    }
}
