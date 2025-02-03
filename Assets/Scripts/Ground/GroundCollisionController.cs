using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] private GroundDataTransmitter groundDataTransmitter;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            groundDataTransmitter.SetGroundRigidBodyValues();
        }
    }
}
