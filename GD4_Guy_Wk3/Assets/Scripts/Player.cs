using JetBrains.Annotations;
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
   float vPlayerMoveSpeed = 15;
   float vPlayerMoveLimit = 20;
    public float vPlayerMoveLimitZ = 15;
    public GameObject vProjectile;
    public GameObject vProjectileHighlight;
    public float vProjHighSizStart = 0.6f;
    public float vProjHighSiz = 0.6f;
    public GameObject vThrowStart;
    public Vector3 vThrowStartPos;
    public float vThrowPower;
    public float vThrowPowerInc=0.6f;
    public float vThrowSpeedLimit = 100;
    public Rigidbody rb;
    public Transform vparent;

   Vector3 vMove;

    public Vector3 vOffset;


    // Baskets
    public Vector3 vBPos1;
    public Vector3 vBPos2;
    public Vector3 vBPos3;
    public Vector3 vBPos4;
    public Vector3 vBPos5;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       vOffset = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
         //Get input
        float vPlayerInput = Input.GetAxis("Horizontal");
        float vPlayerInputZ = Input.GetAxis("Vertical");
        

        // turn low value to nil
        if (vMove.sqrMagnitude < .1)
        { vMove = Vector3.zero; }
        
        vMove = new Vector3 (vPlayerInput, 0, vPlayerInputZ).normalized *vPlayerMoveSpeed *Time.deltaTime;

        /*
        // turn low value to nil
        if (vMove.sqrMagnitude < .1)
        { vMove = Vector3.zero; }
        */

        transform.Translate(vMove);

        if (vMove.sqrMagnitude < .1)
        { vMove = Vector3.zero; }



        //Check for Left Right out of bounds and limit
        if (transform.position.x  < (-vPlayerMoveLimit + vOffset.x))
        {
            transform.position = new Vector3(-vPlayerMoveLimit + vOffset.x, transform.position.y, transform.position.z);   
        }

        if (transform.position.x > (vPlayerMoveLimit+vOffset.x))
        {
            transform.position = new Vector3(vPlayerMoveLimit + vOffset.x, transform.position.y, transform.position.z);
        }

        //Check for FWd/Back out of bounds and limit
        if (transform.position.z < (-vPlayerMoveLimitZ + vOffset.z))
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, -vPlayerMoveLimitZ +vOffset.z);
        }

        if (transform.position.z > (vPlayerMoveLimitZ + vOffset.z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, vPlayerMoveLimitZ + vOffset.z);
        }


        //Check for basket in front and close

        /*
        for (int i=1 ; i <= 5;i++)
        {

           


        }
        */

        Vector3 vB1 = transform.position - vBPos1;
        Vector3 vB2 = transform.position - vBPos2;
        Vector3 vB3 = transform.position - vBPos3;
        Vector3 vB4 = transform.position - vBPos4;
        Vector3 vB5 = transform.position - vBPos5;

        //Detect in view

       

        // Spawn Projectile
        vThrowStartPos = vThrowStart.transform.position;


        
        if (Input.GetButtonDown("Fire1"))
           
        {
            Debug.Log("Start: " + vThrowStartPos);
           
           Instantiate(vProjectile, vThrowStartPos, vparent.rotation,vparent);
            Instantiate(vProjectileHighlight, vThrowStartPos, Quaternion.identity, vparent);
           
        }

     /*   if(Input.GetButton("Fire1"))
        {

            vThrowPower = vThrowPower + vThrowPowerInc*Time.deltaTime;

            vProjHighSiz = vProjHighSizStart * (1+vThrowPower/vThrowSpeedLimit);

            vProjectileHighlight.transform.localScale = vProjectileHighlight.transform.localScale * vProjHighSiz ;


        }

        if (Input.GetButtonUp("Fire1"))
        {
            


            vThrowPower = 0;
           
        }
     */



    }
}