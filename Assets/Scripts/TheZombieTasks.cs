using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class TheZombieTasks : MonoBehaviour
{

    float movex;
    float movey;
    [SerializeField] float cubex;
    [SerializeField] float cubey;
    [SerializeField] float cubez;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundcheckDistance;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask isGround;

    [SerializeField] RaycastHit Hit;

    [SerializeField] Transform targetDirection;
   

    [SerializeField] float controllModifier;

    bool isGrounded;
    [SerializeField] float jumpForce = 5f;
    Renderer rend;
    Rigidbody rb;
    [SerializeField] float moveSpeed = 10f;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        
        

    }



    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            colorChange();
            SpinTheCube(45f, 45, 45);
        }

        if (GroundCheck())

        {
          Debug.Log("Moolick ki mkc");
          isGrounded = true;
        }
            
    
        

        MoveTheCuve();

        
    }

    void Update()
    {
        isGrounded = GroundCheck();
        controllModifier = isGrounded ? 1f : 0.03f;
        movex = Input.GetAxis("Horizontal") * moveSpeed * controllModifier;
        movey = Input.GetAxis("Vertical") * moveSpeed * controllModifier;
        
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)

        {
            JumpYouFool();
            isGrounded = false;
        }
            
    }

    void colorChange()
    {
        rend.material.color = Color.cyan;
    }

    void SpinTheCube(float xRot, float yRot, float zRot)
    {
        transform.Rotate(xRot, yRot, zRot);

    }

    void MoveTheCuve()
    {
        //transform.Translate(movex, 0, movey);
        rb.linearVelocity = new UnityEngine.Vector3(movex, rb.linearVelocity.y, movey);
    }

    void JumpYouFool()
    {

        rb.AddForce(UnityEngine.Vector3.up *jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void ClimbYouFool()
    {
        
    }


    public bool GroundCheck() => Physics.CheckSphere(groundCheck.position, groundCheckRadius, isGround);
    
    
  
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);


    }
}
