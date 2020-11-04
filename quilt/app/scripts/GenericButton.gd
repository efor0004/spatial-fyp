extends Button

class_name GenericButton

signal generic_button_down(generic_button)
signal generic_button_up(generic_button)

func _ready():
	flat = true
	enabled_focus_mode = FOCUS_NONE
	
	connect("button_down", self, "_on_button_down")
	connect("button_up", self, "_on_button_up")

func _on_button_down():
	emit_signal("generic_button_down", self)

func _on_button_up():
	emit_signal("generic_button_up", self)
