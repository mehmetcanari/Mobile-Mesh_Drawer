using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _endText;
    
    public void CallText()
    {
        _endText.gameObject.SetActive(true);
    }
}
