extends AnimatedSprite

func _ready():
	idle()

func idle():
	play_animation("idle")

func on_correct_option():
	play_animation("correct")

func on_incorrect_option():
	play_animation("incorrect")

func play_animation(name):
	var animation_name = get_animation_name(name)
	if (animation != animation_name):
		play(animation_name)

func get_animation_name(name):
	return "%d_%s" % [global.character_index, name]

func _on_Character_animation_finished():
	idle()
