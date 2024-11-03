using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerHealth", menuName = "ObjectHealth/playerHealth" )]
public class HealthSCTO : ScriptableObject
{
    public float maxHp;
    public float currentHp;
}
