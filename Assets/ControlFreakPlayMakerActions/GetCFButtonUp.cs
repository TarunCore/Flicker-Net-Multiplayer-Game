using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Input)]
[Tooltip("Sends an Event when a Button is released.")]
public class GetCFButtonUp : FsmStateAction
{
	[RequiredField]
	[Tooltip("The name of the button. Set in the CFInput class.")]
	public FsmString
		buttonName;
	[Tooltip("Event to send if the button is released.")]
	public FsmEvent
		sendEvent;
	[UIHint(UIHint.Variable)]
	[Tooltip("Set to True if the button is released.")]
	public FsmBool
		storeResult;
	
	public override void Reset ()
	{
		buttonName = "Fire1";
		sendEvent = null;
		storeResult = null;
	}
	
	public override void OnUpdate ()
	{
		var buttonUp = CFInput.GetButtonUp (buttonName.Value);
		
		if (buttonUp) {
			Fsm.Event (sendEvent);
		}
		
		storeResult.Value = buttonUp;
	}
}