using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Transform rayCastOrigin;
    // Start is called before the first frame update
    void Start()
    {
        rayCastOrigin = Camera.main.transform;
    }

    private void Update()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward, Color.cyan);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out RaycastHit hit))
        {
            print(hit.collider);
        }
    }
}