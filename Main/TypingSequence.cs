using Godot;
using System;
using System.Diagnostics;
using Godot.Collections;

public class TypingSequence : Node2D
{
	private Array<string> sequenceToType = new Array<string>("Test typing", "Good test! Hahaha",
		"Auntie, I want no skin on my chicken breast.");
	private int sequenceTracker = 0;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sequenceToType = new Array<string>("Test typing", "Good test! Hahaha",
			"Auntie, I want no skin on my chicken breast.");
	}

	public void SetSequence(Array<string> sequence)
	{
		sequenceToType = sequence;
	}

	public Array<string> GetSequence()
	{
		return sequenceToType;
	}

	public string GetCurrent()
	{
		if (sequenceTracker >= GetSequence().Count)
		{
			return "";
		}

		return GetSequence()[sequenceTracker];
	}

	public bool Progress()
	{
		sequenceTracker += 1;
		return sequenceTracker < GetSequence().Count;
	}
}

//var sequenceToType = ["Test typing", "Good test! Hahaha", "Auntie, I want no skin on my chicken breast."]
//var sequenceTracker = 0
//
//func set_sequence(sequence):
//	sequenceToType = sequence
//
//func get_sequence():
//	return sequenceToType
//
//func get_current():
//	if sequenceTracker >= get_sequence().size():
//		return ""
//	return get_sequence()[sequenceTracker]
//
//func progress():
//	sequenceTracker += 1
//	if sequenceTracker >= get_sequence().size():
//		return false
//	return true

