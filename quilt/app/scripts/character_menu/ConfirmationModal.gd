extends ConfirmationDialog

var scale = 4

var width = global.window_size.x * 2/3
var height = global.window_size.y * 1/2

class_name ConfirmationModal

func _ready():
	self.rect_scale = Vector2(scale, scale)
	var label = get_child(1)
	label.align = Label.ALIGN_CENTER
	label.valign = Label.VALIGN_CENTER

func open():
	var size = Vector2(width, height) / scale
	var position = Vector2(global.window_center.x - width / 2, global.window_center.y - height / 2)
	popup(Rect2(position, size))
