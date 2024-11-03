using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] protected GameObject playerFollow;

    private void LateUpdate()
    {
       this.FollowToPlayer();
    }

    protected void FollowToPlayer()
    {
        this.transform.position = playerFollow.transform.position + new Vector3(0, 2, -10);
    }
}
