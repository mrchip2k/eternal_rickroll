package main

import "fmt"

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
			
			statWordsCount++
			statWordsEach[text]++

			current = next
		}

		// Print a whole line at once rather than words.
		// Better performance and cleaner scrolling.
		fmt.Println(lineBuf)
	}
}

func stats() {
	fmt.Println("---RICK SUCCESSFULLY ROLLED.---")
	fmt.Println("[STATS]")
	fmt.Printf("Lines: %d\n", lines)
	fmt.Printf("Words: %d\n", statWordsCount)
	for key, value := range statWordsEach {
		fmt.Printf("%s: %d\n", key, value)
	}
}
