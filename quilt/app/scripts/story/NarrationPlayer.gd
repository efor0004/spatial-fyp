extends AudioStreamPlayer

var intro_path = "res://assets/audio/story/intro.wav"
var early_winter_path = "res://assets/audio/story/early_winter.wav"
var cold_path = "res://assets/audio/story/cold.wav"
var can_you_help_path = [
	"res://assets/audio/story/help_1.wav",
	"res://assets/audio/story/help_2.wav",
	"res://assets/audio/story/help_3.wav",
	"res://assets/audio/story/help_4.wav",
	"res://assets/audio/story/help_5.wav",
	"res://assets/audio/story/help_6.wav"
]
var fabric_bits_path = "res://assets/audio/story/fabric_bits.wav"
var pick_piece_path = "res://assets/audio/story/pick_piece.wav"
var make_squares_path = "res://assets/audio/story/make_squares.wav"

func play_file(path):
	stream = load(path)
	play()

func play_intro():
	play_file(intro_path)

func play_early_winter():
	play_file(early_winter_path)

func play_cold():
	play_file(cold_path)

func play_help():
	play_file(can_you_help_path[global.character_index - 1])

func play_fabric_bits():
	play_file(fabric_bits_path)

func play_pick_piece():
	play_file(pick_piece_path)

func play_make_squares():
	play_file(make_squares_path)
