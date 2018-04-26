using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDeskNum : MonoBehaviour {
    int num;
    public void SetNum(int n)
    {
        num = n;
    }
    public int GetNum()
    {
        return num;
    }
}
