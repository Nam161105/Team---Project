using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player_Move;
public class Check_wall : MonoBehaviour
{
    [SerializeField] protected Player_Move _Move;


    private void OnTriggerStay2D(Collider2D collision)
    {
        _Move._onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _Move._onGround = false;
    }
}
