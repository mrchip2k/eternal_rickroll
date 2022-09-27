NAME = eternal_rickroll

CC = gcc
CFLAGS = -Wall -Wextra -Werror

SOURCES = main.c
OBJECTS = $(SOURCES:.c=.o)

$(NAME): all

all: $(OBJECTS)
	$(CC) $(CFLAGS) $(OBJECTS) -o $(NAME)

clean:
	rm -f $(OBJECTS)

fclean:
	rm -f $(NAME)

re: fclean all