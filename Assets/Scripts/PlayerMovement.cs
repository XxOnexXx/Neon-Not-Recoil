using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;


    [SerializeField] float runSpeed = 10;
    float Xinput;
    float Yinput;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }


    void Update()
    {
        Xinput = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
        Yinput = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;

        //transform.Translate(Xinput, 0, Yinput);

        Vector3 movement = new Vector3(Xinput, 0, Yinput);

        rb.linearVelocity = movement + new Vector3(0, rb.linearVelocity.y, 0);
        
        
    }

    void FixedUpdate()
    {
        
    }


    
    
}
