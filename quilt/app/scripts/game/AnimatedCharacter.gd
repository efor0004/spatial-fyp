extends AnimatedSprite

func _ready():
	play("idle")

func on_correct_option():
	play("correct")

func on_incorrect_option():
	play("incorrect")

func _on_Character_animation_finished():
	if (animation == "correct" or animation == "incorrect"):
		play("idle")
