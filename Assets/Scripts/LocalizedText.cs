using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
#############################
# TOOL MADE BY GEMINITAURUS #
#############################
*/
public class LocalizedText : MonoBehaviour
{

    public bool loadOnStart;
    
    public string Key;//key to get from csv

    private void Start()
    {
        if (loadOnStart)
        {
            UpdateText();
        }
    }
    public void UpdateText()
    {
        Debug.Log("oui");
        TextMeshProUGUI Text = GetComponent<TextMeshProUGUI>();//get component
        string temp = LocalizationSystem.instance.GetLocalizedValue(Key);
        if (!string.IsNullOrEmpty(temp))//if value is valid
        {
            Text.SetText(temp);
        }
        else//invalid
        {
            Text.color = Color.red;
            Debug.LogError("NO VALUE FOR KEY: " + Key);
            //keep the placeholder text in the TMP-UGUI

        }
        //updates text
    }

}
