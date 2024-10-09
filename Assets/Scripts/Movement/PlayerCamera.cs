using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour, IDataPersistance
{
    public Slider slider;
    private float sens;

    public Transform orientation;

    float xRotation;
    float yRotation;
    bool escPressed = false;


    void Start()
    {
        slider.value = sens;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnSliderValueChanged(float newValue)
    {
        sens = newValue;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (escPressed)
            {
                escPressed = false;
            }
            else {
                escPressed = true;
            }
           
        }


        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (!escPressed) {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }

    }

    public void LoadData(GameData data)
    {
        sens = data.sensitivity;
        if(sens==0)
        {
            sens = 200;
        }
    }

    public void SaveData(ref GameData data)
    {
        data.sensitivity = sens;
    }
}
