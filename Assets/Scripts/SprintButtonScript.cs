
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SprintButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float SprintSpeed;
    [SerializeField] private float SprintSpeedMultiplier;
    [SerializeField] private PlayerController _playerController;
    //[SerializeField] private AudioSource sprintAudio;
    private void Start()
    {
        SprintSpeed = 1;
    }
    private void Update()
    {
        if (_playerController._teleport.CanMove)
        {
            if (_playerController.IsJumping)
            {
                StopSprint();
            }
            if (Input.GetKey(KeyCode.LeftShift) && !_playerController.IsJumping)
            {
                StartSprint();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                StopSprint();
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartSprint();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StopSprint();
    }
    public void StartSprint()
    {
        if (_playerController.IsGrounded)
        {
            SprintSpeed = SprintSpeedMultiplier;
            _playerController.IsSprint = true;
            //   sprintAudio.Play();
        }
    }
    public void StopSprint()
    {
        SprintSpeed = 1f;
        _playerController.IsSprint = false;
    }
}
