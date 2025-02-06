using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private BallDataTransmitter ballDataTransmitter;
    [SerializeField] private GameManager gameManager;

    public float ballSpeed;
     

    void Update()
    {
        SetBallMovement();
        if (ballDataTransmitter.GetBallYValue()<-1)
        {
            gameManager.GameOver();
        }

    }

    private void SetBallMovement()
    {
        transform.position += ballDataTransmitter.GetBallDirection() * ballSpeed * Time.deltaTime;
    }
}
