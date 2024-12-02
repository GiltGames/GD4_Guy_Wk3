using JetBrains.Annotations;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
   float vPlayerMoveSpeed = 15;
   float vPlayerMoveLimit = 20;
    public float vPlayerMoveLimitZ = 15;

    Vector3 vMove;

    public Vector3 vOffset;
    
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

        vMove = new Vector3 (vPlayerInput, 0, vPlayerInputZ).normalized *vPlayerMoveSpeed *Time.deltaTime;
              
        transform.Translate(vMove);


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





    }
}