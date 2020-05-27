extends AnimationPlayer

class_name AnimationPlayerWait

signal stop_waiting

func animation_finished():
	emit_signal("stop_waiting")

func _on_AnimationPlayer1_animation_finished(_anim_name):
	animation_finished()

func _on_AnimationPlayer2_animation_finished(_anim_name):
	animation_finished()

func _on_AnimationPlayer3_animation_finished(_anim_name):
	animation_finished()
