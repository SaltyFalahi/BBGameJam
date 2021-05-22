using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameFlags/FlagObj")]
public class Flags : ScriptableObject
{
    public List<bool> flags;
}
