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
    private List<int> shopItemIndexes;
    private int myCoins = 9000;

    void Start()
    {
        SetShopItems();
        buyButton.onClick.AddListener(() => BuyItem());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(currentShopItems.Length);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetShopItems();
            SetShopItems();
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

    public void SetShopItems() {
        int temp = 0;
        shopItemIndexes = new List<int>();
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                int index = Random.Range(0, _items.Count);
                while (shopItemIndexes.Contains(index)) {
                    index = Random.Range(0, _items.Count);
                }
                shopItemIndexes.Add(index);
                currentShopItems[i, j] = _items[index];
                shopItemsUI[temp].GetComponent<Image>().sprite = _items[index].itemSprite;
                shopItemsUI[temp].name = _items[index].itemName;
                int otherTemp = index;
                shopItemsUI[temp].GetComponent<Button>().onClick.AddListener(delegate { SelectItem(otherTemp); });
                temp++;
            }
        }
    }

    public void ResetShopItems() {
        for (int i = 0; i < shopItemsUI.Count; i++) {
            shopItemsUI[i].GetComponent<Button>().onClick.RemoveAllListeners();
            shopItemsUI[i].GetComponent<Image>().sprite = null;
            shopItemsUI[i].name = "GameObject";
        }
    }
}
