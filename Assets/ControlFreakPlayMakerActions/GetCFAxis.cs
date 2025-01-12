﻿using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Input)]
[Tooltip("Gets the value of the specified Input Axis and stores it in a Float Variable. See CFInput class.")]
public class GetCFAxis : FsmStateAction
{
	[RequiredField]
	[Tooltip("The name of the axis. Set in the CFInput class.")]
	public FsmString
		axisName;
	[Tooltip("Axis values are in the range -1 to 1. Use the multiplier to set a larger range.")]
	public FsmFloat
		multiplier;
	[RequiredField]
	[UIHint(UIHint.Variable)]
	[Tooltip("Store the result in a float variable.")]
	public FsmFloat
		store;
	[Tooltip("Repeat every frame. Typically this would be set to True.")]
	public bool
		everyFrame;
		
	public override void Reset ()
	{
		axisName = "";
		multiplier = 1.0f;
		store = null;
		everyFrame = true;
	}
		
	public override void OnEnter ()
	{
		DoGetAxis ();
			
		if (!everyFrame) {
			Finish ();
		}
	}
		
	public override void OnUpdate ()
	{
		DoGetAxis ();
	}
		
	void DoGetAxis ()
	{
		var axisValue = CFInput.GetAxis (axisName.Value);
			
		// if variable set to none, assume multiplier of 1
		if (!multiplier.IsNone) {
			axisValue *= multiplier.Value;
		}
			
		store.Value = axisValue;
	}
}