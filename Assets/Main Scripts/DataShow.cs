using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataShow : MonoBehaviour
{
    public Test test;
    // Start is called before the first frame update
    public Text text;

    float timer;
    bool started = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 2)
        {
            if (true)
            {
                started = true;
                TextUpdate() ;
                timer = 0;
            }
        }
        else timer += Time.deltaTime;
    }

    void TextUpdate()
    {
        text.text = "Serial: " + test.sn
            + "\nProcesor: " + test.processor
            + "\nPłyta główna: " + test.motherboard
            + "\nRam: " + test.ram
            + "\nGrafika: " + test.graphic
            + "\nGłośnik: " + test.speaker
            + "\nBateria: " + test.battery
            + "\nDyski: " + test.discs.Substring(0, test.discs.Length - 1)
            + "\nKamerka: " + test.webcam
            + "\n\n_____TESTY_____"
            + "\nMatryca: " + GLOBAL.grade
            + "\nSpeakers: " + GLOBAL.speakers
            + "\nMicrophone: " + GLOBAL.micro;
    }
}
