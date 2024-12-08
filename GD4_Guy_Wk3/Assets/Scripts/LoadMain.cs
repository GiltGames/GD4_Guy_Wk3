using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    public int Levelchoice;
    public int LevelApplied;
    public Levelset Levelset;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


  public void StartG()

    {
        Levelset.LevelID = Levelchoice;
        LevelApplied = Levelchoice;

       // SceneManager.LoadScene(1);


    }
}
