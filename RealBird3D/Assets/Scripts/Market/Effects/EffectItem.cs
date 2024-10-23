using UnityEngine;

public class EffectItem : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] int isBuyed;
    [SerializeField] int isChosen;

    [Header("GameObjects")]
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject BuyedImage;
    [SerializeField] GameObject chosenImage;


    public  void Buy()
    {
        if(GameStates.cash>=price)
        {
            GameStates.cash -= price;
            isBuyed = 1;
            BuyButton.SetActive(false);
            BuyedImage.SetActive(true);
        }
    }

    public  void Choose()
    {
        if (isChosen == 0)
        {
            chosenImage.SetActive(true);
            isChosen = 1;
            BuyedImage.SetActive(false);
        }
        else
        {
            isChosen = 0;
            BuyedImage.SetActive(true);
            chosenImage.SetActive(false);
        }
    }
}
