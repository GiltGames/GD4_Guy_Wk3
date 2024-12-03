using UnityEngine;

public class DragonMove : MonoBehaviour
{

    public float vDragonMoveSpeed = 1;
    public float vDragonMoveSpeedUp = 5;

    public GameObject other;
    public bool fFed = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
        transform.Translate(Vector3.forward * vDragonMoveSpeed * Time.deltaTime);


        if (fFed )
        {

            transform.Translate(Vector3.up * Time.deltaTime * vDragonMoveSpeedUp);


        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food1")

        {
            Destroy(other.gameObject);
           
           
            fFed = true;

        }
    }



}
