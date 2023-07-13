using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public abstract class Unit : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] protected string ename;
        [SerializeField] protected int healthPoints;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected int damage;
        [SerializeField] protected string armorType;
        [SerializeField] protected int armor;
    }
}