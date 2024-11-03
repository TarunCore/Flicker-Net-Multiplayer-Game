using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Input)]
[Tooltip("Sends an Event when a Key is pressed.")]
public class GetCFKeyDown : FsmStateAction
{
	[RequiredField]
	public KeyCode
		key;
	public FsmEvent sendEvent;
	[UIHint(UIHint.Variable)]
	public FsmBool
		storeResult;
		
	public override void Reset ()
	{
		sendEvent = null;
		key = KeyCode.None;
		storeResult = null;
	}
		
	public override void OnUpdate ()
	{
		bool keyDown = CFInput.GetKeyDown (key);
			
		if (keyDown)
			Fsm.Event (sendEvent);
			
		storeResult.Value = keyDown;
	}
}