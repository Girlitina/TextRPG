using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private Text toolTipText;

    private void Start()
    {
        toolTipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void GenerateToolTip(Item item)
    {
        string statText = "";
        foreach (var stat in item.stats)
        {
            statText +="\n" + stat.Key.ToString() + ": " + stat.Value;
        }
        string tooltip = string.Format("<b>{0}</b>\n{1}\n<b>{2}</b>", item.title, item.description, statText);
        toolTipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
