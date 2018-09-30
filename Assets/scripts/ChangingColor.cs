using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ChangingColor : MonoBehaviour {

	public GameObject panel;//skintone panel

	public SpriteRenderer skin;//to change the skin color
	public SpriteRenderer arm; 
	public Image skinToneModel;
	public Color[] colors; 

	public int chosenColor = 1; 

	//public int colorChosen = 1; //first 
	void Start(){
		skin.color = Color.white;
	}

	void Update(){
		//changeColor (); 
		skinToneModel.color = skin.color;

		for (int i = 0; i < colors.Length; i++) {
			if (i == chosenColor) {
				skin.color = colors [i]; 
				if (arm != null) {
					arm.color = colors [i];
				}
			}
		}
		/*if (EventSystem.current.currentSelectedGameObject != null) {
			skin.color = EventSystem.current.currentSelectedGameObject.
			GetComponent<Image> ().color;
			arm.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().color;
			skinToneModel.color = skin.color;
		}*/

	}

	/*public void OpenPanel(){
		panel.SetActive (true);
	}
	public void ClosePanel(){
		panel.SetActive (false);
	}*/

	public void changePanelState(bool state){
		panel.SetActive (state);
	}

	public void ChangeColor(int index){
		chosenColor = index;
	}
		
}
