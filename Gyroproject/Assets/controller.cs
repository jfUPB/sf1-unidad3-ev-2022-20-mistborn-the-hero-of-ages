using System;
using UnityEngine;
using System.IO.Ports;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class controller : MonoBehaviour
{
    private SerialPort _serialPort;
    private byte[] buffer;

    public string strReceived;
     
    public string[] strData = new string[4];
    public string[] strData_received = new string[4];
    public float qw, qx, qy, qz;
    
    private float waitTime = 0.025f;
    private float timer = 0.0f;
    void Start()
    {
        _serialPort = new SerialPort();
        _serialPort.PortName = "COM10";
        _serialPort.BaudRate = 9600;
        _serialPort.DtrEnable = true;
        _serialPort.Open();
        Debug.Log("Open Serial Port");
        buffer = new byte[12];
    }

    // Update is called once per frame
    void Update()
    { 
        
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = timer - waitTime;
            _serialPort.Write("ask\n");
            
        }
        
        if (_serialPort.BytesToRead >= 12)
        {
            //Debug.Log("entra al if");
            _serialPort.Read(buffer, 0, 12);
            qx = System.BitConverter.ToSingle(buffer, 0);
            //Debug.Log(qx);
            qy = System.BitConverter.ToSingle(buffer, 4);
            qz = System.BitConverter.ToSingle(buffer, 8);
           transform.rotation = new Quaternion(-qy, -qz, qx, qw);

        }
 
        // if (timer >= waitTime)
        // {
        //     timer = 0f;
        // }
        
        
        /*
        strReceived = stream.ReadLine(); //Read the information  

        strData = strReceived.Split(','); 
        if (strData[0] != "" && strData[1] != "" && strData[2] != "" && strData[3] != "")//make sure data are ready
        {
            strData_received[0] = strData[0];
            strData_received[1] = strData[1];
            strData_received[2] = strData[2];
            strData_received[3] = strData[3];
         
            qw = float.Parse(strData_received[0]);
            qx = float.Parse(strData_received[1]);
            qy = float.Parse(strData_received[2]);
            qz = float.Parse(strData_received[3]);
      
            transform.rotation = new Quaternion(-qy, -qz, qx, qw);
            */
    
             
    }
}