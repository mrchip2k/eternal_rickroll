# Eternal Rickroll

![](god%27s%20will.png)

This program outputs lines based on this chart.

It will stop based on line count.

After the generated lines, stats are displayed.

The same program has been rewritten in multiple languages, information on each one can be found in their READMEs. Although they all try to give the same output and behaviour, they might be coded with different approaches.

# Usage

```txt
$> eternal_rickroll
     (Program generates 69420 lines, and stats.)
$> eternal_rickroll 10
     (Program generates 10 lines, and stats.)
$> eternal_rickroll -1
     (ETERNAL MODE)
```

# Output example
```
$> eternal_rickroll 10 > EXAMPLE.txt
$> cat EXAMPLE.txt
Never gonna say goodbye
Never gonna tell a lie and desert you cry
Never gonna let you
Never gonna say goodbye
Never gonna say goodbye
Never gonna let you
Never gonna let you cry
Never gonna tell a lie and desert you up
Never gonna run around and desert you
Never gonna say goodbye
---RICK SUCCESSFULLY ROLLED.---
[STATS]
Lines: 10
Words: 53
$>
```

# Notes

The `Words` stat won't give the same result as reading the text result, for instance using the `wc` shell command.

It counts the transitions between blocks in the image, therefore the block "a lie" counts as 1 instead of 2.
