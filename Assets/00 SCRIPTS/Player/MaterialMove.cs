using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMove : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _weapon = new List<GameObject>();
    protected int _weaponCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._capsule))
        {
            Destroy(collision.gameObject);
            _weaponCount++;

            if (_weaponCount <= _weapon.Count)
            {
                _weapon[_weaponCount - 1].GetComponent<Rigidbody2D>().gravityScale = 3;
            }
        }
    }
}
