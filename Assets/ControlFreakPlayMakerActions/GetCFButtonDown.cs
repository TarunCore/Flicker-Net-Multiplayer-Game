using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Input)]
[Tooltip("Sends an Event when a Button is pressed.")]
public class GetCFButtonDown : FsmStateAction
{
	[RequiredField]
	[Tooltip("The name of the button. Set in the CFInput class.")]
	public FsmString buttonName;
	
	[Tooltip("Event to send if the button is pressed.")]
	public FsmEvent sendEvent;
	
	[Tooltip("Set to True if the button is pressed.")]
	[UIHint(UIHint.Variable)]
	public FsmBool storeResult;
	
	public override void Reset()
	{
		buttonName = "Fire1";
		sendEvent = null;
		storeResult = null;
	}
	
	public override void OnUpdate()
	{
		var buttonDown = CFInput.GetButtonDown(buttonName.Value);
		
		if (buttonDown)
		{
			Fsm.Event(sendEvent);
		}
		
		storeResult.Value = buttonDown;
	}
}
