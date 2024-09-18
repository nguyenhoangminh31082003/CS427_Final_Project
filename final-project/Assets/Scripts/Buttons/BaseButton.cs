using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    public void DisplayWhenPointerEnters()
    {
        TMPro.TextMeshProUGUI text = this.gameObject.transform.Find("Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text.fontStyle = TMPro.FontStyles.Bold | TMPro.FontStyles.Underline;
        text.color = new Color(1, 1, 1, 1);
    }

    public void DisplayWhenPointerExits()
    {
        TMPro.TextMeshProUGUI text = this.gameObject.transform.Find("Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text.fontStyle = TMPro.FontStyles.Normal;
        text.color = new Color(1, 1, 1, 1);
    }

    public virtual void OnPointerClicking()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
