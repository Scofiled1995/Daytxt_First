using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FunctionContainerManager : MonoBehaviour {
	public UIButton shopBtn;
	public UIButton bagBtn;

	private GameObject bagContainer;
	private bool isActive = false;
	// Use this for initialization
	void Start () {
	
		shopBtn.onClick.Add (new EventDelegate(this,"ShopBtnCallBack"));
		bagBtn.onClick.Add (new EventDelegate(this,"BagBtnCallBack"));
		//隐藏的对象无法通过GameObject.Find寻找到
		bagContainer = GameObject.Find ("Bag Container");
		if (!bagContainer)
			return;
		bagContainer.SetActive(isActive);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void BagBtnCallBack()
	{
		Debug.Log ("BtnTest");
		isActive = !isActive;
		bagContainer.SetActive(isActive);
	}
	public void ShopBtnCallBack()
	{
//		SoundsManager.GetInstance ().PlayBackgroundMusic ("Sounds/shop");
		SoundsManager.GetInstance ().PlayEffectSounds ("Sounds/press_button");
	}

}
