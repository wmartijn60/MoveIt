using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private List<List<GameObject>> shopPools;
    [SerializeField] private List<GameObject> shopItemsUI;
    private TempItem[,] currentShopItems = new TempItem[3,3];
    [SerializeField] private List<TempItem> _items;
    private TempItem selectedItem = null;
    [SerializeField] private Image selectedItemImage;
    [SerializeField] private Text itemName;
    [SerializeField] private Text costText;
    [SerializeField] private Button buyButton;
    private int myCoins = 9000;

    void Start()
    {
        int temp = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                currentShopItems[i, j] = _items[temp];
                shopItemsUI[temp].GetComponent<Image>().sprite = _items[temp].itemSprite;
                shopItemsUI[temp].name = _items[temp].itemName;
                int otherTemp = temp;
                shopItemsUI[temp].GetComponent<Button>().onClick.AddListener(delegate { SelectItem(otherTemp); });
                temp++;
            }
        }

        buyButton.onClick.AddListener(() => BuyItem());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(currentShopItems.Length);
        }
    }

    void SelectItem(int index) {
        selectedItem = _items[index];
        selectedItemImage.sprite = selectedItem.itemSprite;
        itemName.text = selectedItem.itemName;
        costText.text = selectedItem.itemCost.ToString() + " munten";
    }

    void BuyItem() {
        if (selectedItem == null) return;
        myCoins -= selectedItem.itemCost;
    }
}
