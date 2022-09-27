#include<stdio.h>
#include<time.h>
#include<stdlib.h>
#include<stdarg.h>

enum e_state {
	e_state_goodbye,
	e_state_say,
	e_state_run,
	e_state_around,
	e_state_never,
	e_state_gonna,
	e_state_tell,
	e_state_a_lie,
	e_state_down,
	e_state_cry,
	e_state_up,
	e_state_you,
	e_state_let,
	e_state_give,
	e_state_make,
	e_state_and,
	e_state_desert,
	e_state_hurt
};

struct s_stats {
	unsigned long words;
	unsigned long nevers;
};

enum e_state pick_random(int count, ...) {
	va_list list;
	int randy = rand() % count;
	int i = 0;
	enum e_state result;
	va_start(list, count); 
	do
	{
		result = va_arg(list, enum e_state);
		i++;
	} while (i < randy);
	return (result);
}

//the state machine
int god_demanded_this(enum e_state state, struct s_stats *stats) {
	for (unsigned int i = 0; i < 69420; i++) {
		switch (state)
		{
		case e_state_goodbye:
			printf(" goodbye");
			state = pick_random(1, e_state_never);
			break;
		case e_state_say:
			printf(" say");
			state = pick_random(1, e_state_goodbye);
			break;
		case e_state_run:
			printf(" run");
			state = pick_random(1, e_state_around);
			break;
		case e_state_around:
			printf(" around");
			state = pick_random(1, e_state_and);
			break;
		case e_state_never:
			printf("\nNever");
			state = pick_random(1, e_state_gonna);
			stats->nevers++;
			break;
		case e_state_gonna:
			printf(" gonna");
			state = pick_random(6, 
				e_state_say,
				e_state_run,
				e_state_tell,
				e_state_let,
				e_state_give,
				e_state_make
			);
			break;
		case e_state_tell:
			printf(" tell");
			state = pick_random(1, e_state_a_lie);
			break;
		case e_state_a_lie:
			printf(" a lie");
			state = pick_random(1, e_state_and);
			break;
		case e_state_down:
			printf(" down");
			state = pick_random(1, e_state_never);
			break;
		case e_state_cry:
			printf(" cry");
			state = pick_random(1, e_state_never);
			break;
		case e_state_up:
			printf(" up");
			state = pick_random(1, e_state_never);
			break;
		case e_state_you:
			printf(" you");
			state = pick_random(4, 
				e_state_never,
				e_state_up,
				e_state_cry,
				e_state_down
			);
			break;
		case e_state_let:
			printf(" let");
			state = pick_random(1, e_state_you);
			break;
		case e_state_give:
			printf(" give");
			state = pick_random(1, e_state_you);
			break;
		case e_state_make:
			printf(" make");
			state = pick_random(1, e_state_you);
			break;
		case e_state_and:
			printf(" and");
			state = pick_random(2, 
				e_state_desert,
				e_state_hurt
			);
			break;
		case e_state_desert:
			printf(" desert");
			state = pick_random(1, e_state_you);
			break;
		case e_state_hurt:
			printf(" hurt");
			state = pick_random(1, e_state_you);
			break;
		
		default:
			return (1);
		}
		stats->words++;
	}
	return (0);
}

int main() {
	struct s_stats stats = {
		.words = 0,
		.nevers = 0,
	};
	
	srand(time(NULL)); // init RNG
	int err = god_demanded_this(e_state_never, &stats);
	
	if (err) 
		printf("\n---/!\\ ERROR: RICKROLL MACHINE BROKE.---\n");
	else
		printf("\n---RICK SUCCESSFULLY ROLLED.---\n");
	printf("[STATS]\n");
	printf("Words: %i\n", (int)stats.words);
	printf("'Never': %i\n", (int)stats.nevers);
	return (err);
}
