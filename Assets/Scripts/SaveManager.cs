using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour 
{
	public static SaveManager Instance { set; get; }
	public SaveState state;

	private void Awake()
	{
		ResetSave();
		DontDestroyOnLoad(gameObject);
		Instance = this;
		Load();

		//Debug.Log(Helper.Serialize<SaveState>(state));
		//Debug.Log(state.skinOwned(4));
		//UnlockSkin(4);
		//Debug.Log(state.skinOwned(4));

	}

	// Save the whole state of this saveState script to the player pref
	public void Save()
	{
		PlayerPrefs.SetString("save",Helper.Serialize<SaveState>(state));
	}

	// Load the previous save state from the player PlayerPrefs
	public void Load()
	{
		// Do we already have a save?
		if(PlayerPrefs.HasKey("save"))
		{
			state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
		}
		else
		{
			state = new SaveState();
			Save();
			Debug.Log("No save file found, creating a new one!");
		}
	}

	// Check if the skin is owned
	public bool IsSkinOwned(int index)
	{
		// Check if the bit is set, if so the skin is owned
		return (state.skinOwned & (1 << index)) !=0;
	}
	// Check if the speed is owned
	public bool IsSpeedOwned(int index)
	{
		// Check if the bit is set, if so the speed is owned
		return (state.speedOwned & (1 << index)) !=0;
	}

	// Attempt buying a skin, return tue/false
	public bool BuySkin(int index, int cost)
	{
		if(state.gold >= cost)
		{
			// Enough money, remove from the current gold stack
			state.gold -= cost;
			UnlockSkin(index);

			// Save progress
			Save();

			return true;
		}
		else
		{
			// Not enough money, return false
			return false;
		}
	}

	// Attempt buying a speed, return tue/false
	public bool BuySpeed(int index, int cost)
	{
		if(state.gold >= cost)
		{
			// Enough money, remove from the current gold stack
			state.gold -= cost;
			UnlockSpeed(index);

			// Save progress
			Save();

			return true;
		}
		else
		{
			// Not enough money, return false
			return false;
		}
	}


	// Unlock a skin in the "skinOwned" int
	public void UnlockSkin(int index)
	{
		// toggle on the bit at index
		state.skinOwned |= 1 << index;
	}
	// Unlock a speed in the "speedOwned" int
	public void UnlockSpeed(int index)
	{
		// toggle on the bit at index
		state.speedOwned |= 1 << index;
	}

	// Reset the whole save file
	public void ResetSave()
	{
		PlayerPrefs.DeleteKey("save");
	}
}
