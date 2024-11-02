

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler
{


    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private bool gamemodeRunning;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource jumpAudio2;
    private void Update()
    {
        if (_playerController._teleport.CanMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (_playerController.IsCoyot)
            {
                if (!_playerController.IsGrounded)
                {
                    jumpForce = 1200;
                }
                else
                {
                    jumpForce = 750;
                }
            }
            else
            {
                jumpForce = 750;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Jump();
    }
    public void Jump()
    {
        if (_playerController.IsGrounded)
        {
            rb.AddForce(jumpForce * player.transform.up);
            _playerController.IsGrounded = false;
            _playerController.IsJumping = true;
            jumpAudio2.Play();
            jumpAudio.Play();
            if (gamemodeRunning)
            {
                _playerController.Animator.SetTrigger("Jump");
                _playerController.CanPlaySound = false;
            }
            StartCoroutine(OnJump());
        }
    }
    public IEnumerator OnJump()
    {
        yield return new WaitForSeconds(0.8f);
        _playerController.IsJumping = false;
    }
}

