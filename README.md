# auxpis-bps
AUXPIS - A portable, variable bench power supply, supporting various input sources

## Components

 - IRFZ44N (for Buck)
 - IRF540N (for Boost)
 - 33uH Inductor (x2)
 - 4700uF 35V and 50V Capacitor
 - ATMEGA328P (Arduino Pro Mini 5V)
 - Diode (x2)
 - 12V SMPS

## Features
 - **CV, CC**
 - Overcurrent / Short Circuit Protection
 - Current Limiting and Current Foldback
 - Programmable **Undervoltage Lockout Protection**
 - **Reverse voltage protection**
 - **Thermal Overload Protection**

### Specification

| __Param__ | Min Value | Max Value | Unit |
| --------- | --------- | --------- | ---- |
| __Input DC__ | 7 | 30 | **V** |
| __Input AC__* | 110 | 220 | V |
| __Output V__ | 2 | 30 | **V** |
| __Max Current__ | - | 26 | **A** |
| __Rated Power__ | - | 180 | **W** |

_*AC input should be connected to unit only using the AC-DC adapter. Directly connecting AC inputs to the unit can lead to damage._

### Contributors
| Name | |
| ---- | --- |
| RITHVIK NISHAD | _19BEE1050_ |
| KARTHIK P AJITHKUMAR | _19BEE1216_ |