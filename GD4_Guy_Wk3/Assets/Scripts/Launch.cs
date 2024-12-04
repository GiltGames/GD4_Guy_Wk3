using UnityEngine;

public class Launch : MonoBehaviour
{

    public Rigidbody rb;

    public float vThrowForce;
    public float vThrowForceInc = 1;
    public float vThrowForceLim = 100;
    public Vector3 vThrowAngle;
   // public GameObject vThrownParent;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButton("Fire1"))
        {

            vThrowForce += vThrowForceInc *Time.deltaTime;

            if(vThrowForce > vThrowForceLim)
            {
                vThrowForce = vThrowForceLim;
            }

        }




        if (rb != null)
        {

            if (Input.GetButtonUp("Fire1"))
            {
rb.isKinematic = false;
                vThrowAngle = transform.forward;

                rb.AddForce(vThrowAngle * vThrowForce);

                transform.SetParent(null);


            }





        }
    }
}
