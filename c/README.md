# C version

## Building and running

> This Makefile depends on `gcc`.
> Alternatively, just build `main.c` with your compiler of choice directly.

_Compilation:_
```
$> make
```

_Resulting executable:_
```
$> ./eternal_rickroll
```

## Status
- [x] No args default line count
- [x] Handle 0 or positive line count
- [x] Infinite mode
- [x] Bad argument count help message
- Errors
	- [x] Argument count bigger than 1
	- [ ] First argument can't be parsed as int
- [ ] No extra newlines or spaces
	- Has extra newline at start
- [ ] Stats: lines and words
	- Complete but non standard names and order
- [ ] Stats: count each word
	- [ ] only display words that have been used