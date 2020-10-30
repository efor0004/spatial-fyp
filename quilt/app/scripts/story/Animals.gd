extends Node2D

onready var narration_player = get_node("NarrationPlayer")
onready var narrative = get_parent()
onready var sample_question = narrative.get_node("SampleQuestion")

onready var buttons = narrative.get_parent().get_node("Buttons")
onready var skip_button = buttons.get_node("Skip Button")
onready var play_button = buttons.get_node("Play Button")

func _ready():
	narration_player.play_intro()
	yield(get_tree().create_timer(0.5), "timeout")
	
	var animal_player = get_child(global.character_index - 1)
	var animal = animal_player.get_child(0)
	animal.enter()
	yield(animal, "setup_done")
	
	yield(narration_player, "finished")
	
	narration_player.play_early_winter()
	yield(narration_player, "finished")
	
	narration_player.play_cold()
	
	animal.react()
	
	yield(narration_player, "finished")
	
	narration_player.play_help()
	animal_player.play("dream")
	
	yield(animal_player, "animation_finished")
	yield(narration_player, "finished")
	yield(get_tree().create_timer(1), "timeout")
	
	narration_player.play_fabric_bits()
	sample_question.play("appear")
	
	yield(narration_player, "finished")
	yield(get_tree().create_timer(1), "timeout")
	
	narration_player.play_pick_piece()
	sample_question.play("select")
	
	yield(sample_question, "animation_finished")
	
	narration_player.play_make_squares()
	
	yield(narration_player, "finished")
	yield(get_tree().create_timer(2), "timeout")
	
	set_buttons()

func set_buttons():
	skip_button.visible = false
	play_button.visible = true
