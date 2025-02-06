    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GroundPositionController : MonoBehaviour
    {
        private GroundSpawnController groundSpawnController;
        private Rigidbody rigidbody;
        [SerializeField] private float endYValue;
        private int groundDirection;
        private GameManager gameManager;

        private float initialScaleX = 1f;  
        private float initialScaleZ = 1f;  
        private float scaleDecreaseRate = 0.05f;  
        private int scoreThreshold = 10;  

        private void Start()
        {
            groundSpawnController = FindObjectOfType<GroundSpawnController>();
            rigidbody = GetComponent<Rigidbody>();
            gameManager = FindObjectOfType<GameManager>();
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

        // Önceki küpün scale deðerlerini al
        float lastScaleX = groundSpawnController.lastGroundObject.transform.localScale.x;
        float lastScaleZ = groundSpawnController.lastGroundObject.transform.localScale.z;


        // Skora baðlý olarak ölçeði hesapla
        float scaleMultiplier = 1f - (gameManager.score / scoreThreshold) * scaleDecreaseRate;
            scaleMultiplier = Mathf.Max(scaleMultiplier, 0.3f);
      
        if (groundDirection == 0)
            {// s z kuculuyor
                transform.localScale = new Vector3(1, 1, initialScaleZ * scaleMultiplier);
                transform.position = new Vector3(
                    groundSpawnController.lastGroundObject.transform.position.x - 1 + ((1 - lastScaleX) / 2),
                    groundSpawnController.lastGroundObject.transform.position.y,
                    groundSpawnController.lastGroundObject.transform.position.z+ ((1-lastScaleX)/2));
            }
            else
        {//  s x kuculuyor
            transform.localScale = new Vector3(initialScaleX * scaleMultiplier, 1, 1);
                transform.position = new Vector3(
                    groundSpawnController.lastGroundObject.transform.position.x - ((1-lastScaleZ)/2),
                    groundSpawnController.lastGroundObject.transform.position.y,
                    groundSpawnController.lastGroundObject.transform.position.z + 1 - ((1 - lastScaleZ) / 2));
            }

            groundSpawnController.lastGroundObject = gameObject;
        }

        private void SetRigidBodyValues()
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }
