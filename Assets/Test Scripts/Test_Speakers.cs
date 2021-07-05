using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test_Speakers : MonoBehaviour
{
    AudioSource @as;
    public Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        @as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        @as.pitch += 0.0005f;
        @as.volume = Slider.value;
    }

    public void SendSpeakersTest(bool test)
    {
        GLOBAL.speakers = test;
        SceneManager.LoadScene(3);
    }
}
