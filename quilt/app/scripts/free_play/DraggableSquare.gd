extends Area2D

var square_size = 160
var fabric_scale = 0.5
var region_size = square_size / fabric_scale

var min_x = square_size / 2
var min_y = square_size / 2
var max_x = 1764
var max_y = global.window_size.y - square_size / 2

var is_dragging = true

func _init(level, question, start_position):
	var collision_shape = CollisionShape2D.new()
	collision_shape.visible = false
	var collision_rectange = RectangleShape2D.new()
	collision_rectange.extents = Vector2(square_size / 2, square_size / 2)
	collision_shape.shape = collision_rectange
	
	add_child(collision_shape)
	
	var texture_path = "res://assets/sprites/fabrics/level_%d/fabric_%d.jpg" % [level, question]
	var fabric_texture = load(texture_path)
	
	var fabric = Sprite.new()
	fabric.set_texture(fabric_texture)
	fabric.scale = Vector2(fabric_scale, fabric_scale)
	
	fabric.region_enabled = true
	fabric.region_rect = Rect2(0, 0, region_size, region_size)
	
	add_child(fabric)
	self.position = start_position

func on_mouse_up(event_position):
	if (event_position.x > max_x):
		queue_free()
	else:
		is_dragging = false

func on_mouse_drag(event_position):
	if is_dragging:
		var x = event_position.x
		var y = event_position.y
		
		var position_to_set = event_position
		
		if (x < min_x):
			position_to_set.x = min_x
		
		if (y < min_y):
			position_to_set.y = min_y
		elif (y > max_y):
			position_to_set.y = max_y
		
		set_position(position_to_set)

func is_inside_square(location):
	var x = self.position.x
	var y = self.position.y
	
	var max_x = x + square_size / 2
	var min_x = x - square_size / 2
	
	var max_y = y + square_size / 2
	var min_y = y - square_size / 2
	
	if (location.x < min_x or location.x > max_x):
		return false
	elif (location.y < min_y or location.y > max_y):
		return false
	else:
		return true

func _unhandled_input(event):
	if event is InputEventMouseButton and is_inside_square(event.position):
		if event.pressed:
			is_dragging = true
		else:
			on_mouse_up(event.position)
	elif event is InputEventMouseMotion:
		on_mouse_drag(event.position)
