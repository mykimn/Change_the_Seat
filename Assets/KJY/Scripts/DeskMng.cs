using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskMng : MonoBehaviour
{
    private static DeskMng _instance = null;
    public static DeskMng Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(DeskMng)) as DeskMng;
                if (_instance == null)
                {
                    Debug.LogError("Error");
                }
            }
            return _instance;
        }
    }

    public int xCount;
    public int yCount;
    public float xInterval;
    public float yInterval;
    public Vector2 firstPos;
    public GameObject desk;
    public GameObject player;
    public GameObject npc;

    public Text scoreTxt;

    List<GameObject> deskList = new List<GameObject>();
    List<GameObject> charList = new List<GameObject>();
    int playerNum;
    int score;
    public int stageNum = 1;
    public int goalScore;
    public GameObject Im;
    public bool isClear = false;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            if (score < goalScore)
            {
                scoreTxt.text = "점수 : " + score.ToString() + "/" + goalScore.ToString();
            }
            else
            {
                scoreTxt.text = "Clear!!";
            }
        }
    }

    private void Start()
    {
        InitDesk();
    }

    private void Update()
    {
        if(score >= goalScore && !isClear)
        {
            Im.SetActive(true);
            isClear = true;
        }
    }


    public bool CheckPlayer(int num)
    {
        if (num == playerNum) return true;
        else return false;
    }

    private void InitDesk()
    {
        charList.Add(player);
        int count = 0;
        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                Vector2 deskPos = new Vector2(firstPos.x + xInterval * i, firstPos.y - yInterval * j);
                GameObject deskObj = Instantiate(desk, deskPos, Quaternion.identity);
                deskObj.GetComponent<InitDeskNum>().SetNum(count);
                if (i == 0 && j == 0)
                {
                    player.transform.position = deskPos;
                }
                else
                {
                    charList.Add(Instantiate(npc, deskPos, Quaternion.identity));
                }
                count++; 
            }
        }
    }
    

    public GameObject GetNpc(int num)
    {
        return charList[num];
    }
    public void ChangeIndex(int num)
    {
        GameObject temp = charList[playerNum];
        charList[playerNum] = charList[num];
        charList[num] = charList[playerNum];
        playerNum = num;
    }
}
