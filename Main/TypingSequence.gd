extends Node2D

class_name TypingSequence

var sequenceToType = ["Test typing", "Good test! Hahaha", "Auntie, I want no skin on my chicken breast."]
var sequenceTracker = 0

func set_sequence(sequence):
	sequenceToType = sequence
	
func get_sequence():
	return sequenceToType
	
func get_current():
	if sequenceTracker >= get_sequence().size():
		return ""
	return get_sequence()[sequenceTracker]
	
func progress():
	sequenceTracker += 1
	if sequenceTracker >= get_sequence().size():
		return false
	return true
