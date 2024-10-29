using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public bool slap;
    public static Controller Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        //SaveSystem.OnSaveLoaded += OnLoadedData;
        //SaveSystem.OnSaveLoadFailed += OnLoadedFailed;
        InitializeCharacter();
    }
    //[SerializeField]
    //private Timer timer;
   
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private Rigidbody rigidbody;
    //[SerializeField]
    //private GameObject sittingCollider;
    [SerializeField] 
    private Transform abbilityList;
    [SerializeField] 
    private float speedK;
    public float speedM = 1;
    [SerializeField]
    private float sprintK;
    [SerializeField]
    private float speedFov;
    
    [SerializeField]
    private Joystick touchMoveJoystick;
    //[SerializeField]
    //private Transform spawnTransform;
   // [SerializeField]
   // private List<BodyPart> bodyParts;
    //[SerializeField]
    //private Transform mainCameraPoint;
    //[SerializeField]
    //private Transform deathCameraPoint;
    //[SerializeField]
    //private Transform headCameraPoint;
    [SerializeField]
    private bool isMobile;
    //[SerializeField]
    //private ParticleSystem respawnParticle;
    //[SerializeField]
    //private ParticleSystem checkpointParticle;
    //[SerializeField]
    //private AudioClip[] stepClips;
    //[SerializeField]
    //private AudioClip[] climbClips;
    //[SerializeField]
    //private AudioSource stepSource;
    //[SerializeField]
    //private AudioSource jumpSource;
    //[SerializeField]
    //private AudioSource groudSource;
    //[SerializeField]
    private Toggle sitToggle;
   // public List<AbilityTimer> currentAbbilityes { get; private set; }

    //hiden
    public CharacterController characterController { get; private set; }
   
   

    //start settings
   

    //set settings
  
    public void SetSpeedForce(Slider v) => speedK = v.value;
    public void SetSprintForce(Slider v) => sprintK = v.value;

    public bool Initialized { get; private set; }
    private void InitializeCharacter()
    {
//        currentAbbilityes = new List<AbilityTimer>();
//#if UNITY_EDITOR
//        isMobile = false;
//#else
//        isMobile = true;
//#endif
        characterController = GetComponent<CharacterController>();
        //cinemachinePOV = connectedCamera.GetCinemachineComponent<CinemachinePOV>();
        //framingTransposer = connectedCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        //startFov = connectedCamera.m_Lens.FieldOfView;
        //targetFov = startFov;
        //connectedCamera.LookAt = mainCameraPoint;
        //connectedCamera.Follow = mainCameraPoint;
        //startDistance = framingTransposer.m_CameraDistance;
        //targetDistance = startDistance;
        //respawnAdCount = 3;

        Initialized = true;
    }
    private void OnDisable()
    {
        //SaveSystem.OnSaveLoaded -= OnLoadedData;
        //SaveSystem.OnSaveLoadFailed -= OnLoadedFailed;
    }

    //save load system
    //private void OnLoadedFailed()
    //{
    //    lastGroundedPoint = spawnTransform.position;
    //    Teleport(spawnTransform.position);
    //}

    //private void OnLoadedData(SaveSystem.SaveSystemData data)
    //{
    //    lastGroundedPoint = data.PlayerPosition;
    //    Teleport(data.PlayerPosition);

    //    //ability
    //    foreach(var i in data.Abilities)
    //    {
    //        i.GetAbility().GetName();
    //        AbilityManager.AddAbilityGlobal(i.GetAbility());
    //    }
    //}

   
    //public void InputJump(bool state)
    //{
    //    if (slap)
    //        return;
    //    if (state)
    //    {
    //        isJumping = true;
    //    }
    //    else
    //    {
    //        isJumping = false;
    //    }
    //}

    private void Update()
    {
        //if (!Initialized) return;

        //if (isDead)
        //{
        //    deadTimer -= Time.deltaTime;
        //    if (deadTimer < 0)
        //    {
        //        Respawn();
        //    }
        //    return;
        //}
       // if (inCannon) return;

        CheckIsGrounded();

        

        //if (isJumping)
        //{
        //    Jump();
        //}

        if (kauotTimer > 0)
        {
            kauotTimer -= Time.deltaTime;
        }
        else
        {
            if (isFalling)
            {
                inJump = true;
            }
        }

        if (slap)
        {
            speedK = 0;
        }
        else
        {
            speedK = 0.12f;
        }
    }
   

    
    private bool _blockInput;
    public bool BlockInput
    {
        get
        {
            return _blockInput;
        }
        set
        {
            _blockInput = value;
            //if (_blockInput)
            //{
            //    cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = 0;
            //    cinemachinePOV.m_VerticalAxis.m_InputAxisValue = 0;
            //}
        }
    }
    private void FixedUpdate()
    {
        if (!Initialized) return;

        //touchDeltaDir = touchDeltaInput.TouchDelta * 0.35f;
        
        //cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = touchDeltaDir.x;
        //cinemachinePOV.m_VerticalAxis.m_InputAxisValue = touchDeltaDir.y;
        //SetFov();
        if (isDead || inCannon)
        {
            return;
        }

        if (!isMobile)
        {
            inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else
        {
            inputVector = touchMoveJoystick.Direction;

        }

        fallGravity = Vector3.Lerp(fallGravity, Physics.gravity * Time.fixedDeltaTime * 2f, 0.05f);
        if (!isGrounded && !isFalling)
        {
            fallGravity = Vector3.zero;
            isFalling = true;
            lastGroundedPoint = transform.position;
            kauotTimer = 0.25f;
        }
        if (isGrounded && isFalling)
        {
            fallGravity = Physics.gravity * Time.fixedDeltaTime * 2f;
            isFalling = false;
            OnGrounded();
        }

      //  LocomotionProcess();
    }

    public void Rotate(float angle)
    {
        animator.transform.rotation = animator.transform.rotation * Quaternion.EulerAngles(0, angle, 0);
    }
    private void LateUpdate()
    {
        if (!Initialized) return;

        if (isDead || inCannon) return;
       
        //startRotPoint.y = 0;
        //endRotPoint.y = 0;
        //Vector3 direction = (Quaternion.LookRotation((endRotPoint - startRotPoint).normalized, Vector3.up) * new Vector3(inputVector.x, 0, inputVector.y)).normalized;

        //if (!isClimbing && direction.magnitude > 0.1f && !isSitting)
        //{
        //    model.transform.rotation = Quaternion.Lerp(animator.transform.rotation, Quaternion.Euler(0, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0), Time.deltaTime * 10);
        //}
        RespawnProcess();
    }

    private void OnGrounded()
    {
        inJump = false;
       // SetClimbing(false);
        jumpVector = Vector3.zero;
        smoothJumpVector = Vector3.zero;
        //groudSource.Play();
    }

    //locomotion
    public Vector2 inputVector { get; private set; }
    private float speed;
    private float sprintSpeed;
    private float stepTimer;
    //public void LocomotionProcess()
    //{
    //    if (isSitting)
    //    {
    //        return;
    //    }

       
    //    sprintSpeed = Mathf.Lerp(sprintSpeed, isSprint ? 1f : 0f, 0.1f);

    //    if (!isClimbing)
    //    {
    //        speed = Mathf.Lerp(speed, direction.magnitude, 0.35f);

    //        if (direction.magnitude > 0.1f)
    //        {
    //            animator.SetFloat("Speed", speed + sprintSpeed);
    //        }
    //        else
    //        {
    //            animator.SetFloat("Speed", speed);
    //        }
    //    }



    //    animator.SetBool("IsFalling", !isGrounded);

    //    if (!isClimbing)
    //    {
    //        characterController.Move((direction * speed * speedK * speedM * (isSprint ? sprintK : 1f)) + GetGravity() + GetJumpGravity());
    //    }
    //    else
    //    {
    //        float yVelocity = speed * speedK * speedM * inputVector.y;
    //        animator.SetFloat("Speed", inputVector.y);
    //        characterController.Move(Vector3.up * yVelocity);
    //    }

    //    //if(direction.magnitude > 0.1f && !isFalling)
    //    //{
    //    //    stepTimer += Time.fixedDeltaTime;
    //    //    if(stepTimer > 0.31f * (isSprint ? 1f : 1.25f))
    //    //    {
    //    //        stepSource.clip = stepClips[Random.Range(0,stepClips.Length)];
    //    //        stepSource.Play();
    //    //        stepTimer = 0f;
    //    //    }
    //    //}
    //    //if (Mathf.Abs(inputVector.y) > 0.1f && isClimbing)
    //    //{
    //    //    stepTimer += Time.fixedDeltaTime;
    //    //    if (stepTimer > 0.25f)
    //    //    {
    //    //        stepSource.clip = climbClips[Random.Range(0, climbClips.Length)];
    //    //        stepSource.Play();
    //    //        stepTimer = 0f;
    //    //    }
    //    //}

    //    bool isHoldAbility = false;
    //    //foreach(var i in currentAbbilityes)
    //    //{
    //    //    if(i.ability.leftItemHold != null)
    //    //    {
    //    //        isHoldAbility = true;
    //    //    }
    //    //}
    //    animator.SetBool("IsHoldingLeft", isHoldAbility);
    //}
  

    //gravity
    private bool isFalling;
    private Vector3 fallGravity;
    public Vector3 GetGravity()
    {
        Vector3 gravity = new Vector3();
        if (isGrounded)
        {
            Debug.Log("Grounded");
            gravity = Vector3.down * Time.fixedDeltaTime;
        }
        else
        {
            gravity = fallGravity;
        }
        //foreach (var i in currentAbbilityes)
        //{
        //    Vector3 grav = i.ability.OnControllerGravity(this);
        //    gravity.x *= grav.x;
        //    gravity.y *= grav.y;
        //    gravity.z *= grav.z;
        //}
        return gravity;
    }
    public Vector3 GetJumpGravity()
    {
        smoothJumpVector = Vector3.Lerp(smoothJumpVector, jumpVector, 0.05f);
        jumpVector = Vector3.Lerp(jumpVector, Vector3.zero, 0.8f);
        return smoothJumpVector;
    }

    //Jump
    private Vector3 jumpVector;
    private Vector3 smoothJumpVector;
    public bool inJump;
    private float kauotTimer;
    public void Jump()
    {
        if ((!inJump) || (isClimbing) || (isSitting))
        {
            //Vibration.Vibrate(10);
            kauotTimer = 0;
            if (isClimbing)
            {
               // SetClimbing(false);
            }
            //else if (isSitting)
            //{
            //    SetIsSitting(false);
            //    return;
            //}
            else
            {
              //  jumpVector = new Vector3(0, jumpK, 0);
            }
            inJump = true;
            animator.SetTrigger("Jump");
            //jumpSource.Play();
        }

    }
    public void RestartJump()
    {
        inJump = false;
    }

    //Sprint
    private bool isSprint;
  
    [SerializeField]
    public float rayLength;
    public LayerMask groundMask;
    //isGrounded
    public bool isGrounded { get; private set; }
    public GameObject groundObject { get; private set; }
    public GameObject farGroundObject { get; private set; }
    private void CheckIsGrounded()
    {
        if (isClimbing)
        {
            isGrounded = false;
            return;
        }
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position + (Vector3.up * 2f), Vector3.down);
        Debug.DrawLine(transform.position, transform.position+(Vector3.up * 2f)+ (Vector3.down * rayLength), Color.green);
        if(Physics.SphereCast(ray,0.2f,out hit, rayLength, groundMask,QueryTriggerInteraction.Ignore))
        {
            groundObject = hit.collider.gameObject;
            
            //Rotation obj = hit.transform.gameObject.GetComponentInParent<Rotation>();
            Rigidbody rigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
            if(rigidbody != null)
            {
                rigidbody.AddForceAtPosition(Vector3.down, hit.point);
                characterController.Move(Vector3.down * Time.deltaTime);
            }
            //if (obj != null)
            //{
            //    groundObject = obj.gameObject;
            //}
            isGrounded = true;
        }
        else
        {
            groundObject = null;
            isGrounded = false;
        }

        RaycastHit hit2 = new RaycastHit();
        if (Physics.SphereCast(ray, 0.2f, out hit2, 10, groundMask, QueryTriggerInteraction.Ignore))
        {
            farGroundObject = hit2.collider.gameObject;
         //   Rotation obj = hit2.transform.gameObject.GetComponentInParent<Rotation>();
            //if (obj != null)
            //{
            //    farGroundObject = obj.gameObject;
            //}
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + (Vector3.down * rayLength), 0.2f);
    }

    //Fov
   
   
    //private void SetFov()
    //{
    //    connectedCamera.m_Lens.FieldOfView = Mathf.Lerp(connectedCamera.m_Lens.FieldOfView, targetFov, 0.1f);
    //    framingTransposer.m_CameraDistance = Mathf.Lerp(framingTransposer.m_CameraDistance, targetDistance, 0.1f);
    //}

    //Climbing
    public bool isClimbing { get; private set; }
    private int climbCount;
    //public void SetClimbing(bool state, float _angle = -1, int _climbCount = 0)
    //{
    //    climbCount += _climbCount;
    //    if (climbCount <= 0) climbCount = 0;
    //    bool isClimb = climbCount > 0 && _climbCount != 0;
    //    if (isClimb && _angle != -1)
    //    {
    //        model.transform.rotation = Quaternion.Euler(0, _angle, 0);
    //    }
    //    isClimbing = isClimb;
    //    animator.SetBool("IsClimbing", isClimb);
    //}

    private bool isSitting;

    //Sitting
    //public void TriggerSitting()
    //{
    //   // SetIsSitting(!isSitting);
    //}
    //public void SetIsSitting(bool state, bool applyVelocity = true)
    //{
    //   // sitToggle.SetToggle(state);
    //    if (!isSitting && state)
    //    {
    //        isSitting = state;
    //        rigidbody.isKinematic = false;
    //       // sittingCollider.SetActive(true);
    //        //if (characterController.velocity.magnitude > 1f) SoundManager.PlaySound(SoundItem.swing);
    //        if (applyVelocity) rigidbody.AddForce(new Vector3(characterController.velocity.x * 100f, characterController.velocity.y > 0 ? 0 : characterController.velocity.y * 100f, characterController.velocity.z * 100f));
    //        characterController.enabled = false;
    //        animator.SetBool("IsSitting", isSitting);
    //    }
    //    if (isSitting && !state)
    //    {
    //        isSitting = state;
    //        rigidbody.isKinematic = true;
    //        sittingCollider.SetActive(false);
    //        characterController.enabled = true;
    //        animator.SetBool("IsSitting", isSitting);
    //        model.transform.localPosition = Vector3.zero;
    //        // model.transform.localRotation = Quaternion.Euler(model.transform.localEulerAngles.x, 0, model.transform.localEulerAngles.z);
    //        characterController.transform.localRotation = Quaternion.Euler(0, 0, 0);
    //        characterController.Move(Vector3.up * 1f);
    //        climbCount = 0;
    //        SetClimbing(false, -1, -1);
    //    }

    //}

    //Spawnpoint
    public Transform spawnpoint { get; private set; }
    public UnityAction OnSetSpawn;
    public bool TrySetSpawnpoint(Transform point)
    {
        if (spawnpoint == point) return false;
        //checkpointParticle.transform.position = point.transform.position;
        //checkpointParticle.Play();
        spawnpoint = point;
        OnSetSpawn?.Invoke();
        //SaveSystem.SaveSystemData data = SaveSystem.Instance.Data;
        //data.PlayerPosition = point.transform.position;
        //SaveSystem.Instance.Data = data;
        return true;
    }
   
    public UnityAction OnRespawn;
    public void Teleport(Vector3 pos)
    {
        characterController.enabled = false;
        transform.position = pos + Vector3.up;
        characterController.enabled = true;
    }
    //public void Respawn(bool withoutAd = false)
    //{
    //    lastGroundedPoint = spawnpoint.position;
    //    connectedCamera.LookAt = mainCameraPoint;
    //    connectedCamera.Follow = mainCameraPoint;
    //    climbCount = 0;

    //    isDead = false;
    //    //foreach (var i in bodyParts)
    //    //{
    //    //    i.DisableRagdoll();
    //    //}

    //    //respawnParticle.Play();
    //    //SetIsSitting(false);
    //    SetClimbing(false);
    //    characterController.enabled = false;
    //    transform.position = spawnpoint.position+Vector3.up;
    //    characterController.enabled = true;
    //    model.SetActive(true);
    //    //if (selectedItemTrigger != null)
    //    //{
    //    //    PickDownObject();
    //    //}
    //    //else
    //    //{
    //    //    animator.SetBool("IsHolding", selectedItem != null);
    //    //}
    //    //SoundManager.PlaySound(SoundItem.respawn);
    //    OnRespawn.Invoke();
    //    if (withoutAd) return;
        
        
    //}

    private Vector3 lastGroundedPoint;
    private bool BlockRespawning;
    public void SetBlockRespawning(bool state)
    {
        BlockRespawning = state;
        lastGroundedPoint = transform.position;
    }
    private void RespawnProcess()
    {
        if (transform.position.y < lastGroundedPoint.y - 15f && (isFalling || rigidbody.velocity.magnitude > 1f) && !BlockRespawning)
        {
        //    Respawn();
        }
    }

    //dead
    private bool isDead;
    private float deadTimer;
    //public void Dead()
    //{
    //    if (!isDead)
    //    {
    //        Vibration.Vibrate(100);
    //        SoundManager.PlaySound(SoundItem.death);
    //        connectedCamera.LookAt = deathCameraPoint;
    //        connectedCamera.Follow = deathCameraPoint;
    //        Vector3 velocity = characterController.velocity;
    //        isDead = true;
    //        deadTimer = 3f;
    //        //ragdoll.transform.rotation = Quaternion.Euler(0, model.transform.eulerAngles.y, 0);
    //        characterController.enabled = false;
    //        foreach (var i in bodyParts)
    //        {
    //            i.EnableRagdoll(isSitting ? rigidbody.velocity * 30 : velocity * 30);
    //        }
    //        model.SetActive(false);

    //    }
    //}

    //holding
    //[SerializeField]
    //private Transform handPosition;
    private GameObject selectedItem;
    //public void PickUpObject(GameObject obj)
    //{
    //   // obj.transform.SetParent(handPosition);
    //    obj.transform.localPosition = Vector3.zero;
    //    selectedItem = obj;
    //    animator.SetBool("IsHolding", true);
    //}

    //public void PickDownObject()
    //{
    //    BankDisplay.instance.OpenTicketDiliveryUI(false);
    //    if (selectedItemTrigger != null)
    //    {
    //        selectedItemTrigger.RespawnItem();
    //        selectedItemTrigger = null;
    //    }
    //    Destroy(selectedItem);
    //    selectedItem = null;
    //    animator.SetBool("IsHolding", false);
    //}

   // private ItemTrigger selectedItemTrigger;
    //public void PickUpTicket(ItemTrigger trigger)
    //{
    //    //AnalyticsManager.SendEvent("Gameplay", "Ticket", "Take");
    //    BankDisplay.instance.OpenTicketDiliveryUI(true);
    //    selectedItemTrigger = trigger;
    //    PickUpObject(Instantiate(trigger.ticketObject));
    //}
    //public bool TicketDestinated(TicketDestination destination)
    //{
    //    if(destination.Source == selectedItemTrigger)
    //    {
    //        //AnalyticsManager.SendEvent("Gameplay", "Ticket", "Destinated");
    //        PickDownObject();
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //cannon

    private bool inCannon;
    //private CannonTrigger cannon;
    //public void EnterCannon(CannonTrigger cannonTrigger)
    //{
    //    if (!inCannon)
    //    {
    //        SetIsSitting(false);
    //        cannon = cannonTrigger;
    //        inCannon = true;
    //        characterController.enabled = false;
    //        StartCoroutine(CannonProcess());
    //    }
    //}
    //private IEnumerator CannonProcess()
    //{
    //    float timer = 0.1f;
    //    while(timer > 0)
    //    {
    //    //    transform.position = Vector3.Lerp(transform.position, cannon.jumpPoint.position, Time.deltaTime * 10f);
    //     //   model.transform.rotation = Quaternion.Lerp(model.transform.rotation, cannon.jumpPoint.rotation,Time.deltaTime * 10f);
    //        yield return new WaitForEndOfFrame();
    //        timer -= Time.deltaTime;
    //    }
    // //   transform.position = cannon.jumpPoint.position;
    //  //  model.transform.rotation = cannon.jumpPoint.rotation;
    //    animator.applyRootMotion = true;
    //    targetDistance = 10f;
    //    animator.SetTrigger("jumpInCannon");
    //    //connectedCamera.LookAt = headCameraPoint;
    //    //connectedCamera.Follow = headCameraPoint;
    //    yield return new WaitForSeconds(0.8f);
    //  //  transform.parent = cannon.shotPosition.transform;
    //  //  cannon.StartRotateCannon();
    //    yield return new WaitForSeconds(1.1f);
    //    transform.SetParent(null);
    //    animator.applyRootMotion = false;
    //    animator.transform.localPosition = Vector3.zero;
    //    animator.transform.localRotation = Quaternion.identity;
    //    animator.SetTrigger("exitCannon");
    //    targetDistance = startDistance;
    //   // transform.position = cannon.shotPosition.position;
    //   // transform.rotation = cannon.shotPosition.rotation*Quaternion.Euler(0,-90,0);
    //   // SetIsSitting(true, false);
    //    rigidbody.velocity = Vector3.zero;
    //    transform.rotation = Quaternion.identity;
    //  //  rigidbody.AddForce(cannon.shotPosition.forward * cannon.force,ForceMode.Impulse);
    //    connectedCamera.LookAt = mainCameraPoint;
    //    connectedCamera.Follow = mainCameraPoint;
    //    inCannon = false;
    //}
    //timer
    //public void SetTimer(bool state)
    //{
    //    if(state)
    //    {
    //        timer.isEnabled = true;
    //    }
    //    else
    //    {
    //        timer.isEnabled = false;
    //    }
    //}

} 
