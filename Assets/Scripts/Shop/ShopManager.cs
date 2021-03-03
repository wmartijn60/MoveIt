using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    //private List<List<GameObject>> shopPools;
    [SerializeField] private List<GameObject> shopItemsUI;
    [SerializeField] private List<TempItem> _items;
    [SerializeField] private List<Weapon> _weapons;
    private TempItem selectedItem = null;
    private Weapon selectedWeapon = null;

    [SerializeField] private Image selectedItemImage;
    [SerializeField] private Text itemName;
    [SerializeField] private Text costText;
    [SerializeField] private Button buyButton;

    //private TempItem[,] currentShopItems = new TempItem[3,3];
    private List<int> shopItemIndexes;
    private RandomItemGen itemGen;
    private int myCoins = 9000;
    public Sprite sprite;

    void Start()
    {
        itemGen = GetComponent<RandomItemGen>();
        GenerateItemPool();
        //_weapons[3].sprite = sprite;
        //Debug.Log(_weapons[2].weaponName);
        SetShopItems();
        buyButton.onClick.AddListener(() => BuyItem());
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(currentShopItems.Length);
        }*/
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetShopItems();
            SetShopItems();
        }
    }

    public void LogThings() {
        for (int i = 0; i < _weapons.Count; i++) {
            Debug.Log(_weapons[i].sprite);
        }
    }

    void GenerateItemPool() {
        _weapons = new List<Weapon>();
        for (int i = 0; i < 16; i++) 
        {
            Weapon temp = itemGen.GenerateRandomItem2();
            _weapons.Add(temp);
        }
    }

    void SelectItem(int index) {
        selectedWeapon = _weapons[index];
        selectedItemImage.sprite = selectedWeapon.sprite;
        itemName.text = selectedWeapon.weaponName;
        costText.text = selectedWeapon.price.ToString() + " munten";
    }

    void BuyItem() {
        if (selectedWeapon == null) return;
        myCoins -= selectedWeapon.price;
    }

    public void SetShopItems() {
        int temp = 0;
        shopItemIndexes = new List<int>();
        for (int i = 0; i < shopItemsUI.Count; i++) {
            int index = Random.Range(0, _weapons.Count);
            while (shopItemIndexes.Contains(index)) {
                index = Random.Range(0, _weapons.Count);
            }
            shopItemIndexes.Add(index);
            shopItemsUI[temp].GetComponent<Image>().sprite = _weapons[index].sprite;
            shopItemsUI[temp].name = _weapons[index].weaponName;
            int otherTemp = index;
            shopItemsUI[temp].GetComponent<Button>().onClick.AddListener(delegate { SelectItem(otherTemp); });
            temp++;
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
