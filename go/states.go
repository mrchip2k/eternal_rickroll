package main

var (
	st_goodbye State
	st_say     State
	st_run     State
	st_around  State
	st_never   State
	st_gonna   State
	st_tell    State
	st_a_lie   State
	st_down    State
	st_cry     State
	st_up      State
	st_you     State
	st_let     State
	st_give    State
	st_make    State
	st_and     State
	st_desert  State
	st_hurt    State
)

func initStates() {
	st_goodbye = State{
		NextList: []*State{&st_never},
		Text:     "goodbye",
	}

	st_say = State{
		NextList: []*State{&st_goodbye},
		Text:     "say",
	}

	st_run = State{
		NextList: []*State{&st_around},
		Text:     "run",
	}

	st_around = State{
		NextList: []*State{&st_and},
		Text:     "around",
	}

	st_never = State{
		NextList: []*State{&st_gonna},
		Text:     "Never",
	}

	st_gonna = State{
		NextList: []*State{&st_say, &st_run, &st_tell, &st_let, &st_give, &st_make},
		Text:     "gonna",
	}

	st_tell = State{
		NextList: []*State{&st_a_lie},
		Text:     "tell",
	}

	st_a_lie = State{
		NextList: []*State{&st_and},
		Text:     "a lie",
	}

	st_down = State{
		NextList: []*State{&st_never},
		Text:     "down",
	}

	st_cry = State{
		NextList: []*State{&st_never},
		Text:     "cry",
	}

	st_up = State{
		NextList: []*State{&st_never},
		Text:     "up",
	}

	st_you = State{
		NextList: []*State{&st_never, &st_up, &st_cry, &st_down},
		Text:     "you",
	}

	st_let = State{
		NextList: []*State{&st_you},
		Text:     "let",
	}

	st_give = State{
		NextList: []*State{&st_you},
		Text:     "give",
	}

	st_make = State{
		NextList: []*State{&st_you},
		Text:     "make",
	}

	st_and = State{
		NextList: []*State{&st_desert, &st_hurt},
		Text:     "and",
	}

	st_desert = State{
		NextList: []*State{&st_you},
		Text:     "desert",
	}

	st_hurt = State{
		NextList: []*State{&st_you},
		Text:     "hurt",
	}
}
