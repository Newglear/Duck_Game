using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public Transform player;
    public float lerpFactor;
    private float zOffset = -10.0f;
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraTransform.position = Vector3.Lerp( cameraTransform.position, player.position + Vector3.forward * zOffset, lerpFactor );
    }
}
