using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public enum CharacterType
    {
        TypeA,
        TypeB,
        TypeC,
    }
    public abstract class BaseCharacter : MonoBehaviour
    {
       public CharacterType characterType {get;protected set;}
    }
}
