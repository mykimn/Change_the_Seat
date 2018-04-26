using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    public float moveSpeed;
    public bool isPlayer;
    bool isMoving;
    Vector3 targetPos;
    bool teacherCheck;

    public Sprite[] charSprites;
    SpriteRenderer charRender;

    private void Awake()
    {
        charRender = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        moveSpeed *= DeskMng.Instance.stageNum;
    }

    public void StartMove(Vector3 pos, float time)
    {
        if(pos.x == transform.position.x)
        {
            if(pos.y < transform.position.y)
            {
                charRender.sprite = charSprites[1];
            }
        }
        else
        {
            if(pos.x > transform.position.x)
            {
                charRender.sprite = charSprites[2];
            }
            else if (pos.x < transform.position.x)
            {
                charRender.sprite = charSprites[3];
            }
        }

        isMoving = true;
        targetPos = pos;
        if(isPlayer)
        {
            StartCoroutine(ScoreAdd(time));
        }
    }

    IEnumerator ScoreAdd(float waitTime)
    {
        while (isMoving)
        {
            DeskMng.Instance.Score += 5;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Teacher.Instance.isTeacherReturn && !teacherCheck && isPlayer)
            {
                Debug.Log("들킴");
                Gauge.Instance.increaseGauge(false);
                teacherCheck = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
            if (transform.position == targetPos)
            {
                charRender.sprite = charSprites[0];
                isMoving = false;
                if(isPlayer)
                {
                    if(teacherCheck)
                        teacherCheck = false;
                    else
                    Gauge.Instance.increaseGauge(true);

                }
            }
        }
    }

    public bool GetMoving()
    {
        return isMoving;
    }
}
