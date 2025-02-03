using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPositionController : MonoBehaviour
{

    private GroundSpawnController groundSpawnController;
    private Rigidbody rigidbody;
    [SerializeField] private float endYValue;
    private int groundDirection;

    private void Start()
    {
        groundSpawnController = FindObjectOfType<GroundSpawnController>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckGroundYValue();
    }

    private void CheckGroundYValue()
    {
        if (transform.position.y < endYValue)
        {
            SetRigidBodyValues();

            SetGroundNewPosition();
        }

    }

    private void SetGroundNewPosition()
    {
        groundDirection = Random.Range(0, 2);

        if (groundDirection == 0)
        {
            transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x - 1, groundSpawnController.lastGroundObject.transform.position.y, groundSpawnController.lastGroundObject.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x, groundSpawnController.lastGroundObject.transform.position.y, groundSpawnController.lastGroundObject.transform.position.z + 1);
        }
        groundSpawnController.lastGroundObject = gameObject;
    }
    private void SetRigidBodyValues()
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;
    }

}
