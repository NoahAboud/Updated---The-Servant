using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour
{
    public CapsuleCollider playerCollider;
    public Transform playerMesh;
    public Transform playerCamera;
    public float crouchSpeed = 2f;
    public float normalHeight = 2f;
    public float crouchHeight = 1f;
    public float cameraNormalY = 0.9f;
    public float cameraCrouchY = 0.5f;

    private bool crouching;

    void Start()
    {
        playerCollider.height = normalHeight;

        Vector3 meshPos = playerMesh.localPosition;
        meshPos.y = playerCollider.height / 2f;
        playerMesh.localPosition = meshPos;

        Vector3 camPos = playerCamera.localPosition;
        camPos.y = cameraNormalY;
        playerCamera.localPosition = camPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = !crouching;
        }

        float targetHeight = crouching ? crouchHeight : normalHeight;
        float targetCamY = crouching ? cameraCrouchY : cameraNormalY;

        playerCollider.height = Mathf.MoveTowards(playerCollider.height, targetHeight, crouchSpeed * Time.deltaTime);

        Vector3 meshPos = playerMesh.localPosition;
        meshPos.y = playerCollider.height / 2f;
        playerMesh.localPosition = meshPos;

        Vector3 camPos = playerCamera.localPosition;
        camPos.y = Mathf.MoveTowards(camPos.y, targetCamY, crouchSpeed * Time.deltaTime);
        playerCamera.localPosition = camPos;
    }
}
