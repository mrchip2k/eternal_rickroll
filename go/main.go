package main

import (
	"fmt"
	"math/rand"
	"os"
	"strconv"
	"time"
)

var (
	args           []string
	lines          int
	statWordsCount int
	statWordsEach  map[string]int = make(map[string]int)
)

type State struct {
	NextList []*State
	Text     string
}

func runState(current *State) (*State, string) {
	var idx = rand.Intn(len(current.NextList))
	return current.NextList[idx],
		current.Text
}

func main() {
	args = os.Args[1:]
	rand.Seed(time.Now().UnixNano())
	initStates()

	switch len(args){
	case 0:
		roll(69420, false)
	case 1:
		requestedRolls, err := strconv.Atoi(args[0])
		if err != nil {
			fmt.Fprintln(os.Stderr, "Argument 1 couldn't be parsed as an integer number.")
			os.Exit(1)
		} else {
			if requestedRolls < 0 {
				roll(123, true)
			} else {
				roll(requestedRolls, false)
			}
		}
	default:
		fmt.Fprintln(os.Stderr, `Bad argument count.
Expected:
No arguments (generate default amount of lines, 69420)
1 argument (generate this amount of lines OR negative number for infinity)`)
		os.Exit(1)
	}
	stats()
}
