using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnightCronicle
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName;        // 카드 이름
        public string cardDescription; // 카드 설명
        public int summonCost;         // 소환 코스트
        public int attack;             // 공격력
        public int defense;            // 방어력
        public AttributeType attribute; // 속성
        public FactionType faction;    // 진영

        public enum AttributeType
        {
            Fire,
            Earth,
            Water,
            Dark,
            Light,
            Air
        }

        public enum FactionType
        {
            Holy,        // 신성
            Darkness,    // 어둠
            Wilderness   // 황야
        }
    }
}
