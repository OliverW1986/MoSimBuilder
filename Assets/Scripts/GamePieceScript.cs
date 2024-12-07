using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceScript : MonoBehaviour
{
    [SerializeField] private GameObject colliderParent;

    [SerializeField] private Rigidbody rb;

    public bool lowPerformanceMode;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (lowPerformanceMode)
        {
            rb.solverIterations = 1;
            rb.solverVelocityIterations = 1;
        }
    }

    public void ReleaseToWorld(float vel, float sideSpin, float backSpin)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = transform.forward.normalized * vel;
        rb.angularVelocity = new Vector3(0,sideSpin,-backSpin);
        
        transform.parent = transform.root.parent;
        
        EnableColliders();
        StartCoroutine(IgnoreRobot());
    }

    public void MoveToPose(Transform pos)
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        DisableColliders();
        gameObject.transform.position = pos.position;
        gameObject.transform.rotation = pos.rotation;
        gameObject.transform.parent = pos;
    }

    private void DisableColliders()
    {
        colliderParent.SetActive(false);
    }

    private void EnableColliders()
    {
        colliderParent.SetActive(true);
    }

    private IEnumerator IgnoreRobot()
    {
        rb.excludeLayers = LayerMask.GetMask("Robot");
        
        yield return new WaitForSeconds(0.1f);

        rb.excludeLayers = new LayerMask();
    }

    public void Destroy()
    {
        DestroyImmediate(gameObject);
    }
    
    
}
