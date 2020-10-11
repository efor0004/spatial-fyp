extends Node2D

onready var animation_player = get_node("AnimationPlayer")
onready var narration_player = get_node("NarrationPlayer")
onready var buttons = get_parent().get_parent().get_node("Buttons")
onready var skip_button = buttons.get_node("Skip Button")
onready var play_button = buttons.get_node("Play Button")

onready var last_animal = animation_player.get_child(5).get_child(0)

func _ready():
	for animal_player in animation_player.get_children():
		var animal = animal_player.get_child(0)
		animal.enter()
		yield(animal, "setup_done")
	
	for animal_player in animation_player.get_children():
		var animal = animal_player.get_child(0)
		animal.play("idle")
	
	narration_player.play_intro()
	yield(narration_player, "finished")
	
	narration_player.play_early_winter()
	yield(narration_player, "finished")
	
	for animal_player in animation_player.get_children():
		var animal = animal_player.get_child(0)
		animal.load_react()
	
	animation_player.play("react")
	yield(animation_player, "animation_finished")
	
	narration_player.play_cold()
	
	var i = 0
	
	for animal_player in animation_player.get_children():
		i = i + 1
		if (i != global.character_index):
			animal_player.play("exit")
	
	yield(narration_player, "finished")
	
	narration_player.play_help()
	animation_player.play("%d_dream" % global.character_index)
	
	yield(animation_player, "animation_finished")
	yield(narration_player, "finished")
	
	set_buttons()

func set_buttons():
	skip_button.visible = false
	play_button.visible = true
