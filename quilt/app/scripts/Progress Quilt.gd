extends Sprite

var quilt_size = 384

var initial_quilt_piece_x = 1136
var quilt_piece_x = initial_quilt_piece_x
var quilt_piece_y = 0

func add_quilt_piece(current_question, fabric_path):
	var scale = 0.25
	var width_height = quilt_size * scale
	
	var piece = Sprite.new()
	var mask = Light2D.new()
	mask.mode = Light2D.MODE_MIX
	mask.scale = Vector2(scale,scale)
	
	var fabric = Sprite.new()
	fabric.region_enabled = true
	fabric.region_rect = Rect2(0, 0, quilt_size, quilt_size)
	fabric.scale = Vector2(scale,scale)
	
	var fabric_canvas = CanvasItemMaterial.new()
	fabric_canvas.blend_mode = BLEND_MODE_MIX
	fabric_canvas.light_mode = CanvasItemMaterial.LIGHT_MODE_LIGHT_ONLY
	
	piece.add_child(mask)
	fabric.material = fabric_canvas
	piece.add_child(fabric)
	
	var piece_shape = get_quilt_square()
	mask.set_texture(piece_shape)
	
	var piece_fabric = get_fabric(fabric_path)
	fabric.set_texture(piece_fabric)
	
	var piece_size_x = width_height
	
	quilt_piece_x = quilt_piece_x + piece_size_x

	if current_question == 1:
		quilt_piece_x = initial_quilt_piece_x
		var piece_size_y = width_height
		if quilt_piece_y == 0:
			quilt_piece_y = quilt_piece_y + piece_size_y / 2
		else:
			quilt_piece_y = quilt_piece_y + piece_size_y
	
	var new_piece_pos = Vector2(quilt_piece_x, quilt_piece_y)
	piece.transform.origin = new_piece_pos
	
	add_child(piece)

func get_fabric(fabric_path):
	var fabric = load(fabric_path)
	return fabric

func get_quilt_square():
	var path = "res://assets/sprites/questions/square.png"
	var square = load(path)
	return square
