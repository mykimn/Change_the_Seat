using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour {
    public static Teacher Instance;
    private void Awake()
    {
        Teacher.Instance = this;
    }


    public float ReturnTime;
    public float RandomAmount;
    public bool isTeacherReturn;
    public Animator t_Anim;


    void Start () {
        StartCoroutine(TeacherRandom());
        isTeacherReturn = false;
    }
	
    float GetRandomTime()
    {
        return Random.Range(ReturnTime - RandomAmount, ReturnTime + RandomAmount);
    }

    IEnumerator TeacherRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomTime());
            t_Anim.SetTrigger("turn1");
            yield return new WaitForSeconds(0.5f);
            isTeacherReturn = true;
            yield return new WaitForSeconds(GetRandomTime() * 0.5f);
            t_Anim.SetTrigger("turn2");
            yield return new WaitForSeconds(0.5f);
            isTeacherReturn = false;
        }

    }
}
