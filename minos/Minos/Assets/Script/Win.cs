using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
public class Win : MonoBehaviour {

	public Animator DoorAnim;


	public Text fir;
	public Text sec;
	public Text thr;
	public Text fou;

	public void AddFir(){
		Add (fir);
	}

	public void MinusFir(){
		Minus (fir);
	}

	public void AddSec(){
		Add (sec);
	}

	public void MinusSec(){
		Minus (sec);
	}

	public void AddThr(){
		Add (thr);
	}

	public void MinusThr(){
		Minus (thr);
	}

	public void AddFou(){
		Add (fou);
	}

	public void MinusFou(){
		Minus (fou);
	}

	public void Click(){
		if (fir.text == "1" && sec.text == "4" && thr.text == "7" && fou.text == "3") {
			DoorAnim.SetBool ("Open", true);
		}
	}

	void Add(Text t){
		if (t.text == "9") {
			t.text = "0";
		} else {
			t.text = ((t.text[0] - '0') + 1) + "";
		}
	}

	void Minus(Text t){
		if (t.text == "0") {
			t.text = "9";
		} else {
			t.text = ((t.text[0] - '0') - 1) + "";
		}
	}
}
