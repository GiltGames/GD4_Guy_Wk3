using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    public int Levelchoice;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Levelchoice= 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


  public void StartG(int Level)

    {

        SceneManager.LoadScene(Level);


    }
}
