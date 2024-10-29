using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float yAxis;
    [SerializeField] private float xAxis;
    [SerializeField] private float rotationSensitivity = 8f;

    [SerializeField] private Transform target;
    [SerializeField] private float distance;

    [SerializeField] private float rotationMin;
    [SerializeField] private float rotationMax;
    [SerializeField] private float smoothTime;

    [SerializeField] private bool isMobile;
    [SerializeField] private FixedTouchField touchField;
    Vector3 targetRotation;
    Vector3 currentVel;

    private void Start()
    {
        if(isMobile)
        {
           // distance = 10f;
            //rotationMin = -10f;
            //rotationMax = 60f;
            //smoothTime = 0.2f;
            //rotationSensitivity = 0.39f;


        }
    }
    void LateUpdate()
    {
        if (isMobile)
        {
            yAxis += touchField.TouchDist.x * rotationSensitivity;
            xAxis -= touchField.TouchDist.y * rotationSensitivity;
        }
        else
        {
            yAxis += Input.GetAxis("Mouse X") * rotationSensitivity;
            xAxis -= Input.GetAxis("Mouse Y") * rotationSensitivity;
        }
        xAxis = Mathf.Clamp(xAxis, rotationMin, rotationMax);

        targetRotation = Vector3.SmoothDamp(targetRotation,new Vector3(xAxis,yAxis), ref currentVel, smoothTime);
        transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * distance;
    }
}
