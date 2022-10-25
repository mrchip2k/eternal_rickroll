package main

func roll(rolls int, infinite bool) {
	var current *State = &st_never
	lines = 0

	// Line loop
	for ; infinite || lines < rolls; lines++ {
		var lineBuf = ""

		var lineDone = false
		// Word loop
		for !lineDone {
			var next, text = runState(current)

			lineBuf += text
			if next == &st_never {
				lineDone = true
			} else {
				lineBuf += " "
			}
			current = next
		}

		println(lineBuf)
	}
}

//TODO: stats function
func stats() {
	println("---RICK SUCCESSFULLY ROLLED.---")
	println("[STATS]")
}
