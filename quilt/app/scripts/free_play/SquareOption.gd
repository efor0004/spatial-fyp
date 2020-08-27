extends Area2D

class_name SquareOption

onready var palette = get_parent()

func on_input_event(event):
	var is_disabled = get_is_disabled()
	if !is_disabled and event is InputEventMouseButton:
		var index = int(self.name)
		if event.pressed:
			palette.on_option_down(index, event.position)
		else:
			palette.on_option_up(index)

func get_is_disabled():
	var fabric = get_node("Fabric")
	var self_modulation = fabric.self_modulate
	var alpha = self_modulation.a
	
	if (alpha < 1):
		return true
	else:
		return false

func _on_1_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_2_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_3_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_4_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_5_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_6_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_7_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_8_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_9_input_event(_viewport, event, _shape_idx):
	on_input_event(event)

func _on_10_input_event(_viewport, event, _shape_idx):
	on_input_event(event)
