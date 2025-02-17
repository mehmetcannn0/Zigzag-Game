using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    private Vector3 offset;
    private Vector3 newPosition;
    [SerializeField] [Range(0,3)] private float lerpValue;

    void Start()
    {
        offset = transform.position - ballTransform.position;

    }
 
    private void LateUpdate()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        newPosition = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition ;
    }
}
