extends Node2D

func _input(event):
	var eventText = event.as_text()
	if event is InputEventKey and !event.is_echo() and event.is_pressed():
		if event.get_scancode() >= 65 and event.get_scancode() <= 90:
			print(eventText.to_ascii())
			$TypingDisplay.text += eventText
		if event.get_scancode() == KEY_ENTER and event.get_scancode() == KEY_SPACE:
			$TypingDisplay.text = ""
