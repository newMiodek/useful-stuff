# Useful Stuff
**SignificantFigures2** and **DecimalPoints** jump back and forth between converting numbers to strings and strings to numbers.
They were chosen to be implemented like this because of the distrust in functions like Math.Round(x),
which sometimes seem to output stuff like 123.000000000001, even though an integer was expected. Screw them.


**SignificantFigures** is implemented in a dumb way, could use some improvements.

**SignificantFigures2** seems to be better than version 1. Be careful though - it wasn't tested.

**DecimalPoints** probably works. It was tested and the current version seems to produce correct results.
