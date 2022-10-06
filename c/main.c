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
	long words;
	long nevers;
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
	} while (i <= randy);
	return (result);
}

//the state machine
int god_demanded_this(enum e_state state, struct s_stats *stats, long lines_to_generate) {
	while (
		(lines_to_generate < 0)
		|| (stats->nevers <= lines_to_generate)
	) {
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
			stats->nevers++;
			if (
				(lines_to_generate < 0)
				|| (stats->nevers <= lines_to_generate)
			) {
				printf("\nNever");
			}
			state = pick_random(1, e_state_gonna);
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
	stats->nevers--;
	return (0);
}

int main(int argc, char **argv) {
	long lines_to_generate = 69420;
	if (argc > 2) {
		printf("Bad argument count.\n");
		printf("Expected:\n");
		printf("No arguments (generate default amount of lines, 69420)\n");
		printf("1 argument (generate this amount of lines OR negative number for infinity)\n");
		return (1);
	}
	if (argc == 2)
		lines_to_generate = atoi(argv[1]);
	
	struct s_stats stats = {
		.words = 0,
		.nevers = 0,
	};
	
	srand(time(NULL)); // init RNG
	int err = god_demanded_this(e_state_never, &stats, lines_to_generate);
	
	if (err) 
		printf("\n---/!\\ ERROR: RICKROLL MACHINE BROKE.---\n");
	else
		printf("\n---RICK SUCCESSFULLY ROLLED.---\n");
	printf("[STATS]\n");
	printf("Words: %i\n", (int)stats.words);
	printf("'Never': %i\n", (int)stats.nevers);
	return (err);
}
