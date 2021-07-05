using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLOBAL : MonoBehaviour
{
    public static GLOBAL GL;

    public static string grade;
    public static bool speakers, micro;
    // Start is called before the first frame update

    private void Awake()
    {
        if (GL != null)
            GameObject.Destroy(GL);
        else
            GL = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
