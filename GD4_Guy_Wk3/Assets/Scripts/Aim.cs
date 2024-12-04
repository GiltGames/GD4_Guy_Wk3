using Unity.Hierarchy;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public float vMouseSpeed = 10f;
    public float vTiltLimit = 45f;
    public float vAngleLimit = 15f;
    public float vEulerTol = 1f;

    public Vector3 vCamEuler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles = new Vector3(01, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float vMouseX = Input.GetAxis("Mouse X");
        float vMouseY = Input.GetAxis("Mouse Y");
      //  transform.eulerAngles  = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

        vCamEuler = transform.eulerAngles;

        transform.Rotate(0, vMouseX * vMouseSpeed * Time.deltaTime, 0);
        transform.Rotate(-vMouseY * vMouseSpeed * Time.deltaTime, 0,0);


        if ((transform.eulerAngles.z > vEulerTol && transform.eulerAngles.z < 180) || (transform.eulerAngles.z < (360 - vEulerTol) && transform.eulerAngles.z > 180))

        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (transform.eulerAngles.y> vTiltLimit && transform.eulerAngles.y <180)
        {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x,vTiltLimit, 0);

        }


        if (transform.eulerAngles.y < (360-vTiltLimit) && transform.eulerAngles.y > 180)
        {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 360-vTiltLimit, 0);

        }


     if(transform.eulerAngles.x < (360- vAngleLimit) && transform.eulerAngles.x > 180)
        {

            transform.eulerAngles = new Vector3((360-vAngleLimit),transform.eulerAngles.y, 0);

        }


        if (transform.eulerAngles.x > (vAngleLimit) && transform.eulerAngles.x < 180)
        {

            transform.eulerAngles = new Vector3((vAngleLimit), transform.eulerAngles.y, 0);

        }




    }
}
