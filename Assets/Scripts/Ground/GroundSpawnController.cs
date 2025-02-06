using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnController : MonoBehaviour
{
    public GameObject lastGroundObject;
    [SerializeField] private GameObject groundPrefab;
    private GameObject newGroundObject;
    private int groundDirection;

    [SerializeField] private GameObject groundsParent;

    void Start()
    {
        GenerateRandomNewGround();
    }
     
    public void GenerateRandomNewGround() {
        for (int i = 0; i < 10; i++)
        {
            CreateNewGround();
        }
    }
    private void CreateNewGround()
    {
        groundDirection = Random.Range(0, 2);
        if (groundDirection == 0) //sola doðru
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x - 1, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z), Quaternion.identity,groundsParent.transform);
            lastGroundObject = newGroundObject;
        }
        else
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z + 1), Quaternion.identity,groundsParent.transform);
            lastGroundObject = newGroundObject;
        }
    }
}
