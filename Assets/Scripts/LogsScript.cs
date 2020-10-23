using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsScript : MonoBehaviour
{
    public CharacterMove movementInput = new CharacterMove();
    public Text textLog;
    string displayLogs;

    public void logsText()
    {
       foreach(var steps in movementInput.logInput)
        {
             displayLogs =displayLogs+ steps + "\n";
            
        }
         textLog.text = displayLogs;
    }

}
