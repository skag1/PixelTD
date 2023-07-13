using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Enemy : Unit
    {
        [SerializeField] private int hpCost;
        [SerializeField] private int reward;

        public Enemy(string ename, int healthPoints, int hpCost, float moveSpeed, int damage, string armorType, int armor, int reward)
        {
            this.ename = ename;
            this.healthPoints = healthPoints;
            this.hpCost = hpCost;
            this.moveSpeed = moveSpeed;
            this.damage = damage;
            this.armorType = armorType;
            this.armor = armor;
            this.reward = reward;
        }

        public int HpCost
        {
            get { return hpCost; }
            set { hpCost = value; }
        }

        public float MoveSpeed
        {
            get { return moveSpeed; }
            set { moveSpeed = value; }
        }
    }
}