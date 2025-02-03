using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private BallDataTransmitter ballDataTransmitter;

    [SerializeField] private float ballSpeed;
     

    void Update()
    {
        SetBallMovement();

    }

    private void SetBallMovement()
    {
        transform.position += ballDataTransmitter.GetBallDirection() * ballSpeed * Time.deltaTime;
    }
}
