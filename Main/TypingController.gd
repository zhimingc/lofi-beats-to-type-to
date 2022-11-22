extends Node2D

var typingSequence : TypingSequence
var currentTextToType : String
var currentLetter = 0
var stopTyping = false

func _ready():
	typingSequence = get_tree().get_root().get_node("Node2D/TypingSequence")
	set_text_to_type(typingSequence.get_current())

func set_text_to_type(text):
	$TypingDisplay.bbcode_text = "[color=#32CD32][/color]" + text
	currentTextToType = text
	
func progress_current_letter():
	currentLetter += 1	
	if currentLetter >= currentTextToType.length():
		stopTyping = true
		return
	var ascii= currentTextToType[currentLetter].capitalize().to_ascii()
	print(ascii)
	if ascii.size() <= 0 or ascii[0] < 65 or ascii[0] > 90:
		progress_current_letter()

func reset_typing_vars():
	stopTyping = false
	currentLetter = 0

func _input(event):
	var eventText = event.as_text()
	if event is InputEventKey and !event.is_echo() and event.is_pressed():
		if !stopTyping:
			#print(currentTextToType[currentLetter].capitalize().to_ascii()[0])
			#print(event.get_scancode())
			if currentTextToType[currentLetter].capitalize().to_ascii()[0] == event.get_scancode():
				progress_current_letter()
				var newText = currentTextToType.insert(currentLetter, "[/color]")
				$TypingDisplay.bbcode_text = "[color=#32CD32]" + newText
		if event.get_scancode() == KEY_ENTER or event.get_scancode() == KEY_SPACE:
			if stopTyping:
				if typingSequence.progress():
					reset_typing_vars()
					set_text_to_type(typingSequence.get_current())
				
