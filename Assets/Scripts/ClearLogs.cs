using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearLogs : MonoBehaviour
{
    public Text text;
    public void clearText()
    {
        text.text = " ";
    }
}
