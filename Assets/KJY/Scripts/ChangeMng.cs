using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMng : MonoBehaviour
{
    public GameObject player;
    public float scoreTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !player.GetComponent<MoveChar>().GetMoving() && !DeskMng.Instance.isClear)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (rayHit.collider != null)
            {
                Collider2D col = rayHit.collider;
                if (!DeskMng.Instance.CheckPlayer(col.gameObject.GetComponent<InitDeskNum>().GetNum()))
                {
                    player.GetComponent<MoveChar>().StartMove(col.transform.position, scoreTime);
                    DeskMng.Instance.GetNpc(col.gameObject.GetComponent<InitDeskNum>().GetNum())
                        .GetComponent<MoveChar>().StartMove(player.transform.position, scoreTime);
                    DeskMng.Instance.ChangeIndex(col.gameObject.GetComponent<InitDeskNum>().GetNum());
                }
            }
        }
    }
}
