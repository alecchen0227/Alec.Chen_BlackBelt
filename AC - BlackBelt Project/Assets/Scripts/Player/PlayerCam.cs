using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCam : MonoBehaviour
{
    public float sens;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    private void Start()
    {
        //Lock and Hide the Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the new mouse sensitivity
        sens = PlayerPrefs.GetFloat("currentSensitivity", 1);
        // Get Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens * 200;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens * 200;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
