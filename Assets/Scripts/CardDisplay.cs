using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KnightCronicle;

public class CardDisplay : MonoBehaviour
{

    public Card cardData;

    public Image cardImage;
    public Image factionImage;    // 오른쪽 위 진영 아이콘
    public Image attributeImage;  // 그 아래 속성 아이콘

    public Sprite[] factionTypeIcons;      // 진영별 아이콘
    public Sprite[] attributeTypeIcons;    // 속성별 아이콘

    public TMP_Text nameText; // 카드 이름텍스트
    public TMP_Text cardDescriptionText; // 카드 설명 텍스트
    public TMP_Text defenseText; // 카드 방어력(체력) 텍스트
    public TMP_Text attackText; // 카드 공격력 텍스트
    public TMP_Text summonCostText; // 카드 소환 코스트 텍스트
    public Image[] attributetypeImages; // 속성타입 이미지
    public Image[] factiontypeImages; // 진영타입 이미지

    private Color[] attributetypeColors =
    {
      new Color(191/255f, 1f, 1f, 1f), // 물
      new Color(255/255f, 90/255f, 0f, 1f), //불
      new Color(255/255f, 255/255f, 1f, 1f), // 빛
      new Color(0f, 0f, 0f, 1f),  // 어둠
      new Color(210/255f, 180/255f, 140/255f, 1f), // 땅
      new Color(152/255f, 251/255f, 152/255f, 1f) // 바람
    };

    private Color[] factiontypeColors =
    {
      new Color(255/255f, 255/255f, 1f, 1f), // 신성
      new Color(60/255f, 60/255f, 60/255f, 1f),  // 어둠
      new Color(1f, 219/255f, 0f, 1f) // 황야
    };




    void Start()
    {
        UpdateCardDisplay();

    }

    public void UpdateCardDisplay()
    {
        int factionIndex = (int)cardData.faction;
        int attributeIndex = (int)cardData.attribute;

        // 카드 배경/테두리 색상
        if (factionIndex >= 0 && factionIndex < factiontypeColors.Length)
            cardImage.color = factiontypeColors[factionIndex];
        else
            cardImage.color = Color.white;




        // 진영 아이콘 색상 및 스프라이트
        if (factionImage != null)
        {            
            if (factionTypeIcons != null && factionTypeIcons.Length > factionIndex)
                factionImage.sprite = factionTypeIcons[factionIndex];
            factionImage.color = factiontypeColors[factionIndex];
        }
    

    // 속성 아이콘 색상 및 스프라이트
         if (attributeImage != null)
        {            
            if (attributeTypeIcons != null && attributeTypeIcons.Length > attributeIndex)
                attributeImage.sprite = attributeTypeIcons[attributeIndex];
            attributeImage.color = attributetypeColors[attributeIndex];
        }


        // 텍스트 정보
        nameText.text = cardData.cardName;
        cardDescriptionText.text = cardData.cardDescription;
        defenseText.text = cardData.defense.ToString();
        attackText.text = cardData.attack.ToString();
        summonCostText.text = cardData.summonCost.ToString();

        
    
    }
}
    

