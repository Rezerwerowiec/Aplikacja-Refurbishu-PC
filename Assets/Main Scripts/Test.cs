using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;
using System.IO;
using System;
using System.Diagnostics;

public class Test : MonoBehaviour
{
    public string sn, system, processor, ram, graphic, speaker, battery, motherboard, discs, grade;
    public bool webcam, speakers, micro;
    // Start is called before the first frame update
    void Start()
    {


        UnityEngine.Debug.Log("System: Windows " + SystemInfo.operatingSystem
            + "Processor: " + SystemInfo.processorType + " " + SystemInfo.processorFrequency + " MHz"
            + ", RAM: " + SystemInfo.systemMemorySize + " MB"
            + ", Karta graficzna: " + SystemInfo.graphicsDeviceName
            + ", Speaker: " + SystemInfo.supportsAudio
            + ", Bateria: " + SystemInfo.batteryLevel + "%  " + SystemInfo.batteryStatus
            + ", Motherboard: " + SystemInfo.deviceType + " " + SystemInfo.deviceModel
            + ", S/N: " + SystemInfo.deviceUniqueIdentifier);


        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            UnityEngine.Debug.Log("DYSKI: " + d.TotalSize / 1073741824);
            discs += d.TotalSize / 1073741824 + "GB +";
        }

        system = SystemInfo.operatingSystem;
        processor = SystemInfo.processorType + " " + SystemInfo.processorFrequency + " MHz";
        ram = SystemInfo.systemMemorySize + "MB";
        graphic = SystemInfo.graphicsDeviceName;
        speaker = "" + SystemInfo.supportsAudio;
        battery = SystemInfo.batteryLevel + "% " + SystemInfo.batteryStatus;
        motherboard = SystemInfo.deviceType + " " + SystemInfo.deviceModel;
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            webcam = true;

        Memory();
        SerialNumber();
        grade = GLOBAL.grade;
        speakers = GLOBAL.speakers;
        micro = GLOBAL.micro;
       
    }

    public void CreateCSV()
    {
        TextWriter tw = new StreamWriter(Application.dataPath + "/test.csv", false);
        tw.WriteLine("sn,,system,,processor,,ram,,graphic,,speaker,,battery,,motherboard,,discs,,webcam,,speakers test,,grade,,micro test");
        tw.Close();
        tw = new StreamWriter(Application.dataPath + "/test.csv", true);
        tw.WriteLine(sn + ",," + system + ",," + processor + ",," + ram + ",," + graphic + ",," + speaker + ",," + battery + ",," + motherboard + ",," + discs + ",," + webcam + ",," + speakers + ",," + grade + ",," + micro);
        tw.Close();

        tw = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/test.csv", false);
        tw.WriteLine("sn,,system,,processor,,ram,,graphic,,speaker,,battery,,motherboard,,discs,,webcam,,speakers test,,grade,,micro test");
        tw.Close();
        tw = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/test.csv", true);
        tw.WriteLine(sn + ",," + system + ",," + processor + ",," + ram + ",," + graphic + ",," + speaker + ",," + battery + ",," + motherboard + ",," + discs + ",," + webcam + ",," + speakers + ",," + grade + ",," + micro);
        tw.Close();

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SerialNumber()
    {
        string command = "wmic bios get serialnumber";

        var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardError = true;
        processInfo.RedirectStandardOutput = true;

        var process = Process.Start(processInfo);

        process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
        {
            if (e.Data != "")
            {
                UnityEngine.Debug.Log("output>>" + e.Data);
                sn +=e.Data;
            }
        };
        process.BeginOutputReadLine();

        process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
            UnityEngine.Debug.Log("error>>" + e.Data);
        process.BeginErrorReadLine();

        process.WaitForExit();

        UnityEngine.Debug.Log("ExitCode: " + process.ExitCode);
        process.Close();

    }
    public void Memory()
    {
        //string command = "wmic bios get serialnumber";
        string command = "wmic memorychip get devicelocator, speed";
        var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardError = true;
        processInfo.RedirectStandardOutput = true;

        var process = Process.Start(processInfo);

        process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
        {
            if (e.Data != "" && !e.Data.StartsWith("Dev"))
            {
                UnityEngine.Debug.Log("output>>" + e.Data);
                ram += ", " + e.Data + " MHz";
            }
        };
        process.BeginOutputReadLine();

        process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
            UnityEngine.Debug.Log("error>>" + e.Data);
        process.BeginErrorReadLine();

        process.WaitForExit();

        UnityEngine.Debug.Log("ExitCode: " + process.ExitCode);
        process.Close();

    }
}
