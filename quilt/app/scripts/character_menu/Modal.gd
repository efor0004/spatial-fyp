extends WindowDialog

var width = global.window_size.x * 2/3
var height = global.window_size.y * 1/2

class_name Modal

func open():
	popup_centered(Vector2(width, height))
