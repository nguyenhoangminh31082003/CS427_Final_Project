using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    public void DisplayWhenPointerEnters()
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Bold | TMPro.FontStyles.Underline;
        this.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }

    public void DisplayWhenPointerExits()
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Normal;
        this.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
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
