using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroTest : MonoBehaviour
{
    AudioSource @as;

    // Start is called before the first frame update
    void Start()
    {
        @as = GetComponent<AudioSource>();
        Debug.Log(Microphone.devices);
        @as.clip = Microphone.Start(null, true, 10, 44100);
        @as.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        @as.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendMicroTest(bool test)
    {
        GLOBAL.micro = test;
        SceneManager.LoadScene(0);
    }
}
