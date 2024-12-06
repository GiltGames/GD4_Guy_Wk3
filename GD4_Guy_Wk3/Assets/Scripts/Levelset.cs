using UnityEngine;

public class Levelset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Level;
    public int LevelID;

    private void Awake()
    {
        DontDestroyOnLoad(Level);
    }

}
