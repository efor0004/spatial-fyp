extends Sprite

var quilt_size = 384
var piece_scale = 0.25
var quilt_size_scaled = quilt_size * piece_scale

var holey_quilt_position = Vector2(358, 768)

var initial_quilt_piece_x = 1136
var initial_quilt_piece_y = quilt_size_scaled / 2

var animation_duration = 4

const Constants = preload("../utilities/constants.gd")
var constants = Constants.new()

const GeneralUtils = preload("../utilities/general.gd")
var general_utils = GeneralUtils.new()

signal done_animating

func add_pre_animation_piece(fabric_path):
	add_quilt_piece(fabric_path, holey_quilt_position, 1)

func add_all_pieces_for_state():
	for level in range(1, global.current_level + 1):
		var max_questions = constants.questions_per_level
		
		if (level == global.current_level):
			max_questions = global.current_question - 1
			
		for question in range(1, max_questions + 1):
			var fabric_path = general_utils.get_fabric(level, question)
			var piece_pos = get_piece_end_position(level, question)
			add_quilt_piece(fabric_path, piece_pos, piece_scale)

func add_quilt_piece(fabric_path, piece_pos, scale):
	var width_height = quilt_size * scale
	
	var piece = AnimationPlayer.new()
	
	var piece_sprite = Sprite.new()
	piece_sprite.set_name(get_sprite_name())
	piece_sprite.set_position(piece_pos)
	
	var mask = Light2D.new()
	mask.mode = Light2D.MODE_MIX
	mask.scale = Vector2(scale, scale)
	
	var fabric = Sprite.new()
	fabric.region_enabled = true
	fabric.region_rect = Rect2(0, 0, width_height, width_height)
	fabric.scale = Vector2(scale, scale)
	
	var fabric_canvas = CanvasItemMaterial.new()
	fabric_canvas.blend_mode = BLEND_MODE_MIX
	fabric_canvas.light_mode = CanvasItemMaterial.LIGHT_MODE_LIGHT_ONLY
	
	fabric.material = fabric_canvas
	piece_sprite.add_child(fabric)
	
	var piece_shape = get_quilt_square()
	mask.set_texture(piece_shape)
	
	var piece_fabric = get_fabric(fabric_path)
	fabric.set_texture(piece_fabric)
	fabric.region_enabled = true
	fabric.region_rect = Rect2(80, 80, quilt_size, quilt_size)
	
	piece_sprite.add_child(mask)
	piece.add_child(piece_sprite)
	
	add_child(piece)

func animate_quilt_piece():
	var end_pos = get_piece_end_position(global.current_level, global.current_question)
	
	var current_piece_index = get_current_piece_index()
	var piece = get_child(current_piece_index)
	var piece_sprite = piece.get_node(get_sprite_name())
	var mask_node = piece_sprite.get_child(0)
	var fabric_node = piece_sprite.get_child(1)
	
	var piece_animation = get_piece_animation(end_pos, piece_sprite, mask_node, fabric_node)
	piece.add_animation("move", piece_animation)
	
	piece.play("move")
	yield(piece, "animation_finished")
	emit_signal("done_animating")

func get_current_piece_index():
	var current_piece_index = (global.current_level - 1) * constants.questions_per_level + global.current_question - 1
	return current_piece_index

func get_piece_end_position(level, question):
	var quilt_piece_x = initial_quilt_piece_x + (question - 1) * quilt_size_scaled
	var quilt_piece_y = initial_quilt_piece_y + (level - 1) * quilt_size_scaled
	
	var piece_position = Vector2(quilt_piece_x, quilt_piece_y)
	return piece_position

func get_piece_animation(end_pos, piece_sprite, mask_node, fabric_node):
	var start_pos = holey_quilt_position
	
	var piece_animation = Animation.new()
	piece_animation.set_length(animation_duration)
	
	# Translation
	piece_animation.add_track(Animation.TYPE_VALUE, 0)
	var sprite_path = piece_sprite.get_path()
	var translation_path = "%s:position" % sprite_path
	piece_animation.track_set_path(0, translation_path)
	piece_animation.track_insert_key(0, 0, start_pos)
	piece_animation.track_insert_key(0, animation_duration, end_pos)
	
	# Scale
	var start_scale = Vector2(1,1)
	var end_scale = Vector2(piece_scale, piece_scale)
	
	# Scale - mask
	piece_animation.add_track(Animation.TYPE_VALUE, 1)
	var mask_path = mask_node.get_path()
	var scale_path_mask = "%s:scale" % mask_path
	piece_animation.track_set_path(1, scale_path_mask)
	piece_animation.track_insert_key(1, 0, start_scale)
	piece_animation.track_insert_key(1, animation_duration, end_scale)
	
	# Scale - fabric
	piece_animation.add_track(Animation.TYPE_VALUE, 2)
	var fabric_path = fabric_node.get_path()
	var scale_path_fabric = "%s:scale" % fabric_path
	piece_animation.track_set_path(2, scale_path_fabric)
	piece_animation.track_insert_key(2, 0, start_scale)
	piece_animation.track_insert_key(2, animation_duration, end_scale)
	
	return piece_animation

func get_sprite_name():
	var current_piece_index = get_current_piece_index()
	var sprite_name = "PieceSprite%d" % current_piece_index
	return sprite_name

func get_fabric(fabric_path):
	var fabric = load(fabric_path)
	return fabric

func get_quilt_square():
	var path = "res://assets/sprites/questions/square.png"
	var square = load(path)
	return square
