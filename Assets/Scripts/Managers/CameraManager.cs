using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Camera camera1, camera2, camera3;

    PlayerCustomActions input;

    private void Awake()
    {
        input = new PlayerCustomActions();
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Main.Camera1.WasPressedThisFrame())
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;

            Debug.Log("Camera1");
        }

        if (input.Main.Camera2.WasPressedThisFrame())
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;

            Debug.Log("Camera2");
        }

        if (input.Main.Camera3.WasPressedThisFrame())
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;

            Debug.Log("Camera3");
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }
}
