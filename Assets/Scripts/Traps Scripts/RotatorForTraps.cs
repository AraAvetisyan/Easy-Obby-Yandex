using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorForTraps : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private bool isCoin;
 
    void FixedUpdate()
    {
        if (isCoin)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        if (isHorizontal)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }
}
