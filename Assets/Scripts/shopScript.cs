using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopScript : MonoBehaviour {

	public Transform skinPanel;
	public Transform speedPanel;

	public Text skinBuySetText;
	public Text speedBuySetText;
	public Text goldText;

	private int[] skinCost = new int[] { 5, 10, 20, 50, 100 };
	private int[] speedCost = new int[] { 5, 10, 15, 20, 25 };
	private int selectedSkinIndex;
	private int selectedSpeedIndex;
	private int activeSkinIndex;
	private int activeSpeedIndex;

	// Use this for initialization
	void Start () {
		// TEMPORARY
		SaveManager.Instance.state.gold = 999;
		
		// Tell our gold text how much he should be displaying
		UpdateGoldText();
		
		// Add button on-click events to shop buttons
		InitShop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void InitShop()
	{
		 if (skinPanel == null || speedPanel == null)
		 Debug.Log("You did not asign the panels in the inspector");

		  // For every child transform under the skin panel, find the button and add onclick
		  int i = 0;
		  foreach(Transform t in skinPanel)
		  {
			int currentIndex = i;
			
			Button b = t.GetComponent<Button>();
			b.onClick.AddListener(() => OnSkinSelect(currentIndex));

			// Set the color of the image, based on if owned or not
			Image img = t.GetComponent<Image>();
			img.color = SaveManager.Instance.IsSkinOwned(i) ? Color.white : new Color(0.7f, 0.7f, 0.7f);

			i++;
		  }

		  // Reset Index
		  i = 0;

		  // Do the same for the speed panel
		  foreach(Transform t in speedPanel)
		  {
			int currentIndex = i;
			
			Button b = t.GetComponent<Button>();
			b.onClick.AddListener(() => OnSpeedSelect(currentIndex));

			// Set the color of the image, based on if owned or not
			Image img = t.GetComponent<Image>();
			img.color = SaveManager.Instance.IsSpeedOwned(i) ? Color.white : new Color(0.7f, 0.7f, 0.7f);

			i++;
		  }
	}

private void SetSkin(int index)
{
	// Set the active index
	activeSkinIndex = index;
	
	// Change the Skin of the player

	// Change buy/set button text
	skinBuySetText.text = "Current";
}

private void SetSpeed(int index)
{
	// Set the active index
	activeSpeedIndex = index;
	
	// Change the Speed of the player

	// Change buy/set button text
	speedBuySetText.text = "Current";
}

private void UpdateGoldText()
{
	goldText.text = SaveManager.Instance.state.gold.ToString();
}

// Buttons

	private void OnSkinSelect(int currentIndex)
	{
		Debug.Log("Selecting skin button : " + currentIndex);

		// If the button clicked is already selected, exit
		if (selectedSkinIndex == currentIndex)
		return;

		// Make the icon slightly bigger
		skinPanel.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;

		// Put the previous one on normal scale
		skinPanel.GetChild(selectedSkinIndex).GetComponent<RectTransform>().localScale = Vector3.one;

		// Set the selected skin
		selectedSkinIndex = currentIndex;

		// Change the content of the buy/set button, depending on the state of the skin
		if(SaveManager.Instance.IsSkinOwned(currentIndex))
		{
			// Skin is owned
			if(activeSkinIndex == currentIndex)
			{
				skinBuySetText.text = "Current";
			}
			else
			{
				skinBuySetText.text = "Select";
			}
		}
		else
		{
			// Skin isn't owned			
			skinBuySetText.text = "Buy " + skinCost[currentIndex].ToString();
		}
	}

	private void OnSpeedSelect(int currentIndex)
	{
		Debug.Log("Selecting speed button : " + currentIndex);

		// If the button clicked is already selected, exit
		if (selectedSpeedIndex == currentIndex)
		return;

		// Make the icon slightly bigger
		speedPanel.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;

		// Put the previous one on normal scale
		speedPanel.GetChild(selectedSpeedIndex).GetComponent<RectTransform>().localScale = Vector3.one;

		// Set the selected speed
		selectedSpeedIndex = currentIndex;

		// Change the content of the buy/set button, depending on the state of the speed
		if(SaveManager.Instance.IsSpeedOwned(currentIndex))
		{
			// Speed is owned
			if(activeSpeedIndex == currentIndex)
			{
				speedBuySetText.text = "Current";
			}
			else
			{
				speedBuySetText.text = "Select";
			}
		}
		else
		{
			// Speed isn't owned
			speedBuySetText.text = "Buy " + speedCost[currentIndex].ToString();
		}
	}

	public void OnSkinBuySet()
	{
		Debug.Log("Buy/Set skin");
		// Is the selected skin owned
		if(SaveManager.Instance.IsSkinOwned(selectedSkinIndex))
		{
			// Set the skin
			SetSkin(selectedSkinIndex);
		}
		else
		{
			// Attempt to Buy the skin
			if(SaveManager.Instance.BuySkin(selectedSkinIndex,skinCost[selectedSkinIndex]))
			{
				// Success
				SetSkin(selectedSkinIndex);

				// Change the color of the button
				skinPanel.GetChild(selectedSkinIndex).GetComponent<Image>().color = Color.white;

				// Update gold text
				UpdateGoldText();
			}
			else
			{
				// Do not have enough gold
				// Play sound feedback
				Debug.Log("Not enough gold");
			}
		}
	}

	public void OnSpeedBuySet()
	{
		Debug.Log("Buy/Set speed");
		// Is the selected speed owned
		if(SaveManager.Instance.IsSpeedOwned(selectedSpeedIndex))
		{
			// Set the speed
			SetSpeed(selectedSpeedIndex);
		}
		else
		{
			// Attempt to Buy the speed
			if(SaveManager.Instance.BuySpeed(selectedSpeedIndex,speedCost[selectedSpeedIndex]))
			{
				// Success
				SetSpeed(selectedSpeedIndex);

				// Change the color of the button
				speedPanel.GetChild(selectedSpeedIndex).GetComponent<Image>().color = Color.white;

				// Update gold text
				UpdateGoldText();
			}
			else
			{
				// Do not have enough gold
				// Play sound feedback
				Debug.Log("Not enough gold");
			}
		}
	}
}
