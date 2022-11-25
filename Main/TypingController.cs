using Godot;
using System;
using System.Diagnostics;

public class TypingController : Node2D
{
	private TypingSequence _typingSequence;
	private string currentTextToType;
	private string currentTextToDisplay;
	private int currentLetter;
	private bool stopTyping;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_typingSequence = GetTree().Root.GetNode<TypingSequence>("Node2D/TypingSequence");
		SetTextToType(_typingSequence.GetCurrent());
	}

	void SetTextToType(string text)
	{
		GetNode<RichTextLabel>("TypingDisplay").BbcodeText = "[color=#32CD32][/color]" + text;
		currentTextToType = text.ToUpper();
		currentTextToDisplay = text;
	}

	void ProgressCurrentLetter()
	{
		currentLetter++;
		if (currentLetter >= currentTextToType.Length)
		{
			stopTyping = true;
			return;
		}

		var ascii = currentTextToType[currentLetter];
		GD.Print(ascii + " | " + (ascii < 65) + " | " + (ascii > 90));
		if (ascii < 65 || ascii > 90)
		{
			ProgressCurrentLetter();
		}
	}

	private void ResetTypingVars()
	{
		stopTyping = false;
		currentLetter = 0;
	}

	public override void _Input(InputEvent @event)
	{
		string eventText = @event.AsText();
		InputEventKey keyInput = @event as InputEventKey;
		if (keyInput == null) return;

		if (!keyInput.IsEcho() && keyInput.IsPressed())
		{
			if (!stopTyping)
			{
				GD.Print("scancode: ");
				GD.Print(keyInput.Scancode);
				if (currentTextToType[currentLetter] == keyInput.Scancode)
				{
					ProgressCurrentLetter();
					string newText = currentTextToDisplay.Insert(currentLetter, "[/color]");
					GetNode<RichTextLabel>("TypingDisplay").BbcodeText = "[color=#32CD32]" + newText;
				}
			}

			if (keyInput.Scancode == (int) KeyList.Enter || keyInput.Scancode == (int) KeyList.Space)
			{
				if (stopTyping && _typingSequence.Progress())
				{
					ResetTypingVars();
					SetTextToType(_typingSequence.GetCurrent());
				}
			}
		}
	}
}

//var typingSequence : TypingSequence
//var currentTextToType : String
//var currentLetter = 0
//var stopTyping = false
//
//func _ready():
//	typingSequence = get_tree().get_root().get_node("Node2D/TypingSequence")
//	set_text_to_type(typingSequence.get_current())
//
//func set_text_to_type(text):
//	$TypingDisplay.bbcode_text = "[color=#32CD32][/color]" + text
//	currentTextToType = text
//
//func progress_current_letter():
//	currentLetter += 1	
//	if currentLetter >= currentTextToType.length():
//		stopTyping = true
//		return
//	var ascii= currentTextToType[currentLetter].capitalize().to_ascii()
//	print(ascii)
//	if ascii.size() <= 0 or ascii[0] < 65 or ascii[0] > 90:
//		progress_current_letter()
//
//func reset_typing_vars():
//	stopTyping = false
//	currentLetter = 0
//
//func _input(event):
//	var eventText = event.as_text()
//	if event is InputEventKey and !event.is_echo() and event.is_pressed():
//		if !stopTyping:
//			#print(currentTextToType[currentLetter].capitalize().to_ascii()[0])
//			#print(event.get_scancode())
//			if currentTextToType[currentLetter].capitalize().to_ascii()[0] == event.get_scancode():
//				progress_current_letter()
//				var newText = currentTextToType.insert(currentLetter, "[/color]")
//				$TypingDisplay.bbcode_text = "[color=#32CD32]" + newText
//		if event.get_scancode() == KEY_ENTER or event.get_scancode() == KEY_SPACE:
//			if stopTyping:
//				if typingSequence.progress():
//					reset_typing_vars()
//					set_text_to_type(typingSequence.get_current())
