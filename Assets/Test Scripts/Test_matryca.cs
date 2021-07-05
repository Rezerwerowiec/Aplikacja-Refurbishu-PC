using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test_matryca : MonoBehaviour
{
    int i = 0;
    public Canvas canvas;
    public Camera cam;
    public Text txt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            canvas.enabled = !canvas.enabled;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
            if (i > 8) i = 0;
            switch (i)
            {
                case 0:
                {
                    cam.backgroundColor = Color.red;
                    break;
                }
                case 1:{
                    cam.backgroundColor = Color.blue;
                    break;
                }
                case 2:
                {
                    cam.backgroundColor = Color.black;
                    break;
                }
                case 3:
                {
                    cam.backgroundColor = Color.yellow;
                    break;
                }
                case 4:
                {
                    cam.backgroundColor = Color.white;
                    break;
                }
                case 5:
                {
                    cam.backgroundColor = Color.magenta;
                    break;
                }
                case 6:
                {
                    cam.backgroundColor = Color.grey;
                    break;
                }
                case 7:
                {
                    cam.backgroundColor = Color.cyan;
                    break;
                }
                case 8:
                {
                    cam.backgroundColor = Color.green;
                    break;
                }

            }   
        }
    }
    public void SendGrade()
    {
        GLOBAL.grade = txt.text.ToUpper();
        SceneManager.LoadScene(2);
    }
}
