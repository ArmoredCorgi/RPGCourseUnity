using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float camSpeedH = 4.0f;
    public float camSpeedV = 2.0f;

    GameObject player;
    float gamepadSensitivityOffset = 10.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;
    bool isGamePadActive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        isGamePadActive = Input.GetJoystickNames().Length != 0;

        if( isGamePadActive )
        {
            yaw += camSpeedH * gamepadSensitivityOffset * Input.GetAxis("Right Joystick X");
            pitch += camSpeedV * gamepadSensitivityOffset * Input.GetAxis("Right Joystick Y");
        }
        else
        {
            yaw += camSpeedH * Input.GetAxis("Mouse X");
            pitch -= camSpeedV * Input.GetAxis("Mouse Y");
        }

        pitch = Mathf.Clamp(pitch, -30.0f, 30.0f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
