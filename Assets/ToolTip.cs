using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour
{
    TMP_Text tMP_Text;

    private void Awake()
    {
        tMP_Text = GetComponent<TMP_Text>();
    }

    public void SetToolTip(string text)
    {
        tMP_Text.text = text;
    }
}
