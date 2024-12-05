using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    public Slider vHealthSlider;
    public GameObject vChar;
    public DragonMove DragonMove;
    public float vHungerProp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vChar = transform.parent.gameObject;
        DragonMove =vChar.GetComponent<DragonMove>();
        vHealthSlider = GetComponentInChildren<Slider>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
        
        vHungerProp =( DragonMove.vAppetiteTmp / DragonMove.vHunger);

        vHealthSlider.value = vHungerProp;

    }
}
