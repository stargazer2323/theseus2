using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToMove : MonoBehaviour
{
    public string steps;
    public GameObject inputField;
    public Vector3 position;

    public int getSteps()
    {
        steps = inputField.GetComponent<Text>().text;
        int stepsInt = Int32.Parse(steps);
        return stepsInt;


    }
}