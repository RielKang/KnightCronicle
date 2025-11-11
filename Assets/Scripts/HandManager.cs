using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnightCronicle;


public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab; // Assign card prefab in inspector
    public Transform handTransform; // Root of the hand position
    // 패가 돌아가는 각도
    public float fanSpread = 7.5f;
    // 패를 펼쳤을때 카드별 간격
    public float cardSpacing = 100f;

    public float verticalSpacing = 10f;

    public List<GameObject> cardsInHand = new List<GameObject>(); // Hold list of the card objects in our hand
    
    
    // Start is called before the first frame update
    void Start()
    {
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();
    }

    public void AddCardToHand()
    {
        // Instantiate the card
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        newCard.name = "카드" + cardsInHand.Count;
        cardsInHand.Add(newCard);

        UpdateHandVisuals();

    }

    void Update()
    {
        UpdateHandVisuals();
    }


    
    private void UpdateHandVisuals()
    {
        if(cardsInHand.Count == 1)
        {
            return;
        }

        int cardCount = cardsInHand.Count;
        for (int i=0; i < cardCount; i++)
        {
            float rotationAngle = (fanSpread * (i - (cardCount - 1) / 2f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2f));

            float normalizedPosition = (2f * i / (cardCount - 1) - 1f); //Normalize card position between -1, 1
            float verticalOffset = verticalSpacing * (1 - normalizedPosition * normalizedPosition);

            
            // set card position
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);


        }

    }
}
