using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
   public bool hasItem = false;

   Sprite defaultSprite;
   Text amountText;

   private void Start()
   {
	defaultSprite = GetComponent<Image>().sprite;
	amountText = transform.GetChild(0).GetComponent<Text>();
   }



   private void Update()
   {
		  CheckforItem();
   }

   public void CheckforItem()
   {
		  if(transform.childCount >1)
		  {
				Item i = transform.GetChild(1).GetComponent<Item>();
				hasItem = true;
				GetComponent<Image>().sprite = i.itemSprite;

		  }
		  else 
		  {
			GetComponent<Image>().sprite = defaultSprite;
			amountText.text = "";
		  }
   }
}
