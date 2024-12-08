using JetBrains.Annotations;

using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float vPlayerMoveSpeed = 15;
    public float vPlayerMoveLimit = 20;
    public float vPlayerMoveLimitZ = 15;
    public GameObject vProjectile;
    public GameObject vProjectileHighlight;
    public float vProjHighSizStart = 0.6f;
    public float vProjHighSiz = 0.6f;
    public GameObject vThrowStart;
    public Vector3 vThrowStartPos;
    public float vThrowPower;
    public float vThrowPowerInc = 0.6f;
    public float vThrowSpeedLimit = 100;
    public Rigidbody rb;
    public Transform vparent;

    Vector3 vMove;

    public Vector3 vOffset;
    public Spawn Spawn;
    public int vNooBasket;

    //Food
    public GameObject[] FoodSelect;
    public int vPickup;
    public GameObject[] HighlightSelect;


    // Baskets
    public GameObject[] vBasket;
    public Vector3[] vBPos;
    public Vector3[] vDir;
    public float[] vDis;
    public float vDiff;
    public Vector3 vPlayDir;

    public float vPickupAngle= 0.2f;

    public int close;


    public GameObject vCam1;
    public GameObject vCam2;
    public bool vCam1on;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       vOffset = transform.position;
        transform.rotation = Quaternion.identity;
        vNooBasket = Spawn.vNoofFood;

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

        transform.position = transform.position +  vMove;

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

       //Detect basket distance and direction

        for (int i=0;i<vNooBasket;i++)
        {
            vBPos[i] = vBasket[i].transform.position - transform.position ;
            vBPos[i] = new Vector3(vBPos[i].x, 0, vBPos[i].z);
            vDir[i] = vBPos[i].normalized;
            vDis[i] = vBPos[i].magnitude;
        }

        //Detect closest

         close = 0;
        vPlayDir = new Vector3(transform.forward.x,0,transform.forward.z);
        vPlayDir = vPlayDir.normalized;


        for (int i = 0; i < vNooBasket; i++)
        {
            if (vDis[i] < vDis[close])

            {
                close = i;
            }
        }
            //Highlight closest

        for (int i = 0; i < vNooBasket; i++)

        { 
            if (i == close)
         
            { 
                Transform vChild = vBasket[i].transform.Find("OutlineBasket");
                GameObject vChildObj = vChild.gameObject;
                vChildObj.SetActive(true);

                vDiff = Vector3.Angle(vDir[close],vPlayDir);

                if (vDiff < vPickupAngle)
                {
                    vChildObj.SetActive(true);
                    vPickup = close;
                }

                else
                {

                    vChildObj.SetActive(false);
                    vPickup = 6;
                }

            }
            
            else
            {
                Transform vChild = vBasket[i].transform.Find("OutlineBasket");
                GameObject vChildObj = vChild.gameObject;
                vChildObj.SetActive(false);

            }
        
        }
        


            //Detect in view



            // Spawn Projectile
            vThrowStartPos = vThrowStart.transform.position;


        
        if (Input.GetButtonDown("Fire1") && vPickup<6)
           
        {
            Debug.Log("Start: " + vThrowStartPos);

            vProjectile = FoodSelect[vPickup];
            vProjectileHighlight = HighlightSelect[vPickup];

           Instantiate(vProjectile, vThrowStartPos, vparent.rotation,vparent);

            Instantiate(vProjectileHighlight, vThrowStartPos, Quaternion.identity, vparent);
           
        }



        if(Input.GetKeyDown(KeyCode.C))
        {
            if(vCam1on)
            {
                vCam1on = false;
                vCam1.SetActive(false);
                vCam2.SetActive(true);

            }
            else
            {
                vCam1on = true;
                vCam2.SetActive(false);
                vCam1.SetActive(true);


            }

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