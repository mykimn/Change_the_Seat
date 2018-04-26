using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;
	// Use this for initialization
	void Start () {
        Value = 10;
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}
    public float MaxValue
    {
        get;
        set;
    }
    public float Value
    {
        set
        {
            fillAmount = Map(value,0,MaxValue,0,1);
        }
    }
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Map(53, 0, 100, 0, 1);
        }
        
    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}