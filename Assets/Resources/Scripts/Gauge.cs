using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour {

    public static Gauge Instance;
    private void Awake()
    {
        Gauge.Instance = this;
    }

    public Image slider;
    public float decreaseSpeed;
    public GameObject ReplayIm;
    public bool isDead = false;
    public float increaseAmount;
    public float decreaseAmount;

    private void Start()
    {
        StartCoroutine(GaugeCor());
    }

    private void Update()
    {
        if(slider.fillAmount <= 0 && !isDead)
        {
            ReplayIm.SetActive(true);
            isDead = true;
        }
    }

    IEnumerator GaugeCor()
    {
        while (!DeskMng.Instance.isClear)
        {
            slider.fillAmount -= Time.deltaTime * decreaseSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
    public void increaseGauge(bool tof)
    {
        if (tof)
        {
            SFXMng.instance.SFXPlay(0);
            slider.fillAmount += increaseAmount;
        }
        else
        {
            SFXMng.instance.SFXPlay(1);
            slider.fillAmount -= decreaseAmount;
        }
    }
    public void Init()
    {
        slider.fillAmount = 1f;
    }
}
