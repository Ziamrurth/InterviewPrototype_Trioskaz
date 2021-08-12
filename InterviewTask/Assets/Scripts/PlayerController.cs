using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float mouseSensivity = 100f;
    public float speed = 12f;

    private Transform _mainCamera;
    private CharacterController _charController;
    private float _xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _mainCamera = Camera.main.transform;
        _charController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;

        _mainCamera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        _charController.Move(move * speed * Time.deltaTime);
    }
}
