
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
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_playerController.IsGrounded)
        {
            SprintSpeed = SprintSpeedMultiplier;
            _playerController.IsSprint = true;
         //   sprintAudio.Play();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        SprintSpeed = 1f;
        _playerController.IsSprint = false;
    }
}
