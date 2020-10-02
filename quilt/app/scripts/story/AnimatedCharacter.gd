extends AnimatedSprite

class_name AnimatedCharacter

const LOOPING_ANIMATIONS = ["idle", "move"]

func _on_Character_animation_finished():
	if (!LOOPING_ANIMATIONS.has(animation)):
		play("idle")
