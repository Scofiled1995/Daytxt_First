using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AngryBallState))]

public class AngryBallControll : MonoBehaviour {
	public float moveSpeed = 3f;
	/*
	 * 屏幕左边控制按钮
	 */
	public bool screenLeftCanMove = true;
	public GameObject leftMove;//向左
	public GameObject rightMove;//向右
	public GameObject forwardMove;//向前
	public GameObject backMove;//向后

	/*
	 * 屏幕右边控制按钮
	 */
	public bool screenRightCanMove = true;
	public GameObject leftMove2;//向左
	public GameObject rightMove2;//向右
	public GameObject forwardMove2;//向前
	public GameObject backMove2;//向后

	public bool isPressed = false;//按钮是否处于按下状态

	//插值阻尼
	public float valueDamping = 2f;
	public float targetValue = 1;
	public float currentValue = 0;
	//力
	public float forceH = 0f;//水平方向
	public float forceV = 0f;//垂直方向

	[System.Serializable]public enum ScreenLeftButtonState{
		None = -1,
		LeftMovePress = 0,
		RightMovePress,
		ForwardMovePress,
		BackMovePress
	}

	[System.Serializable]public enum ScreenRightButtonState{
		None = -1,
		LeftMovePress = 0,
		RightMovePress,
		ForwardMovePress,
		BackMovePress
	}

    public ScreenLeftButtonState screenLeftBtnState;//左边控制
	public ScreenRightButtonState screenRightBtnState;//右边控制

	private Rigidbody rig;//小球的刚体组件
	// Use this for initialization
	void Start () {
		rig = transform.GetComponent<Rigidbody> ();
		AddEventListenerForButton ();
	}

	//添加按钮事件
	void AddEventListenerForButton()
	{
		BindFunction (leftMove);
		BindFunction (rightMove);
		BindFunction (forwardMove);
		BindFunction (backMove);
		BindFunction (leftMove2);
		BindFunction (rightMove2);
		BindFunction (forwardMove2);
		BindFunction (backMove2);

	}
	//给每个按钮绑定回调函数
	void BindFunction(GameObject button)
	{
		UIEventTrigger ue = button.AddComponent<UIEventTrigger>();
		ue.onRelease.Add (new EventDelegate(this,"ReleasedButton"));
		ue.onPress.Add (new EventDelegate(this,"PressButton"));
		ue.onPress[0].parameters[0] = new EventDelegate.Parameter();
		ue.onPress [0].parameters [0].obj = button;
//		UIEventListener.Get (button).onClick = ClickButton;
	}
	//按下按钮回调
	void PressButton(GameObject obj)
	{

		isPressed = true;
		AdjustScreenLeftButtonState(obj.name,obj.tag);
		InvokeRepeating ("RepeatFunc",0,Time.deltaTime);

	}
	//判断哪个按钮按下
	void AdjustScreenLeftButtonState(string btnName,string btnTag)
	{
		switch (btnName) {
		case "Left Move":
			if (btnTag.Equals ("screenLeft") && screenLeftCanMove)
				screenLeftBtnState = ScreenLeftButtonState.LeftMovePress;
			else if(btnTag.Equals ("screenRight") && screenRightCanMove)
				screenRightBtnState = ScreenRightButtonState.LeftMovePress;
			break;
		case "Right Move":
			if (btnTag.Equals ("screenLeft") && screenLeftCanMove)
				screenLeftBtnState = ScreenLeftButtonState.RightMovePress;
			else if(btnTag.Equals ("screenRight") && screenRightCanMove)
				screenRightBtnState = ScreenRightButtonState.RightMovePress;
			break;
		case "Forward Move":
			if (btnTag.Equals ("screenLeft") && screenLeftCanMove)
				screenLeftBtnState = ScreenLeftButtonState.ForwardMovePress;
			else if(btnTag.Equals ("screenRight") && screenRightCanMove)
				screenRightBtnState = ScreenRightButtonState.ForwardMovePress;
			break;
		case "Back Move":
			if (btnTag.Equals ("screenLeft") && screenLeftCanMove)
				screenLeftBtnState = ScreenLeftButtonState.BackMovePress;
			else if(btnTag.Equals ("screenRight") && screenRightCanMove)
				screenRightBtnState = ScreenRightButtonState.BackMovePress;
			break;
		default:
			break;
		}
	}
	//释放按钮回调
	void ReleasedButton()
	{
		isPressed = false;
		CancelInvoke ();

		currentValue = 0f;
		forceH = 0f;
		forceV = 0f;
	}
	//按下按钮所开启的重复回调函数
	void RepeatFunc()
	{
		currentValue = Mathf.Lerp (currentValue,targetValue,valueDamping*Time.deltaTime);
		//待优化
		//L
		switch (screenLeftBtnState) {
		case ScreenLeftButtonState.LeftMovePress:
			forceH = -currentValue;
			break;
		case ScreenLeftButtonState.RightMovePress:
			forceH = currentValue;
			break;
		case ScreenLeftButtonState.ForwardMovePress:
			forceV = currentValue;
			break;
		case ScreenLeftButtonState.BackMovePress:
			forceV = -currentValue;
			break;
		default:
			break;
		}

		//R
		switch (screenRightBtnState) {
		case ScreenRightButtonState.LeftMovePress:
			forceH = -currentValue;
			break;
		case ScreenRightButtonState.RightMovePress:
			forceH = currentValue;
			break;
		case ScreenRightButtonState.ForwardMovePress:
			forceV = currentValue;
			break;
		case ScreenRightButtonState.BackMovePress:
			forceV = -currentValue;
			break;
		default:
			break;
		}

		rig.AddForce (new Vector3(forceH,0,forceV));
	}


}
