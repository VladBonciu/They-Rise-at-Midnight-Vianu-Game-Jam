using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerLook : MonoBehaviour
{
    
    [SerializeField] public float mouseSensitivity = 100f;
    [SerializeField] private Transform Player;
    public Transform camTransform;
    float xRotation = 0f;  
    [SerializeField] private bool FOVLocked;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    

    Vector3 lastMouseCoordinate = Vector3.zero;


    void Start()
    {
        FOVLocked = false;
    }

    void Update()
    {
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;

        // mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity");

        //Get Axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        float horizontalAxis = Input.GetAxis("Horizontal");

        //Mouse Y Clamping
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        //Actual Rotation
        transform.localRotation =  Quaternion.Slerp( transform.localRotation, Quaternion.Euler(transform.localRotation.x + xRotation, transform.localRotation.y , transform.localRotation.z), Time.deltaTime * 15f);  
        Player.Rotate(Vector3.up * mouseX);
        
        if(horizontalAxis != 0)
        {
            camTransform.localRotation = Quaternion.Slerp( camTransform.localRotation, Quaternion.Euler(camTransform.localRotation.x, camTransform.localRotation.y , horizontalAxis), Time.deltaTime * 10f);  
        }


        if(!FOVLocked)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, 45f, Time.deltaTime * 2f);
            }
            else
            {
                cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, 65f, Time.deltaTime * 2f);
            }
        }
        
    }

    public void LockFOV(float value)
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = value;
        FOVLocked = true;
    }

    public void UnlockFOV()
    {
        FOVLocked = false;
    }
}
