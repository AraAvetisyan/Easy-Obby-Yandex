using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleWheelScript : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float currentRotationSpeed;
    private void FixedUpdate()
    {
        currentRotationSpeed = rotationSpeed * _playerController.CurrentSpeed * Time.deltaTime;
        transform.Rotate(currentRotationSpeed,0, 0);
    }
}
