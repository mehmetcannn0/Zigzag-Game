using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFallController : MonoBehaviour
{
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }
    
    
    public IEnumerator SetRigidBodyValues()
    {
        yield return new WaitForSeconds(0.75f);
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }
}
