using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDataTransmitter : MonoBehaviour
{
    [SerializeField] private BallInputController ballInputController;
    [SerializeField] private BallMovementController ballMovementController;
    public Vector3 GetBallDirection()
    {
        return ballInputController.ballDirection;
    }
    public float GetBallYValue()
    {
        return transform.position.y;
    }
    public void SetBallSpeed(float value)
    {
        ballMovementController.ballSpeed = ballMovementController.ballSpeed + value;
    }


}
