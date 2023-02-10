# Introduction
This is a 16-bit CPU architecture project, along with an assembler capable of accepting the commands listed below, separated by function within the programming.

The assembler is capable of converting from assembly to binary or hexadecimal; to use with Logisim it is necessary to convert to hexadecimal and place it inside the ROM memory that is in the main component.


## OpCodes
<details>
<summary>Legend</summary>

* AAAA = Address of an A register
* BBBB = Address of an B register
* XXXX = Will be ignored
* CCCC CCCC = 8 bit C constant
* LLLL LLLL LLLL = Label used for jumps in 12-bit code

</details>

### ULA
| inst  |        OpCode         |           Description              |
| ----- | --------------------- | ---------------------------------- |
| and   | 1111 0000 AAAA BBBB   | A = A & B                          |
| sub   | 1111 0001 AAAA BBBB   | A = A - B                          |
| mult  | 1111 0010 AAAA BBBB   | A = A * B (Integer Multiplication) |
| div   | 1111 0011 AAAA BBBB   | A = A / B (Integer Division)       |
| nand  | 1111 0100 AAAA BBBB   | A = !(A & B)                       |
| rsh   | 1111 0101 AAAA BBBB   | A = A >> B                         |
| xnor  | 1111 0110 AAAA BBBB   | A = !(A ^ B)                       |
| inc   | 1111 0111 AAAA XXXX   | A = A + 1                          |
| dec   | 1111 1000 AAAA XXXX   | A = A - 1                          |
| xor   | 1111 1001 AAAA BBBB   | A = A ^ B                          |
| not   | 1111 1010 AAAA BBBB   | A = !A                             |
| nor   | 1111 1011 AAAA BBBB   | A = !(A \| B)                      |
| lsh   | 1111 1100 AAAA BBBB   | A = A << B                         |
| add   | 1111 1101 AAAA BBBB   | A = A + B                          |
| ivt   | 1111 1110 AAAA BBBB   | A = -A                             |
| or    | 1111 1111 AAAA BBBB   | A = A \| B                         |

### Jumps
| inst  |        OpCode         |           Description              |
| ----- | --------------------- | ---------------------------------- |
| jump  | 0001 LLLL LLLL LLLL   | Jump                               |
| je    | 0010 LLLL LLLL LLLL   | Jump if equal                      |
| jne   | 0011 LLLL LLLL LLLL   | Jump if not equal                  |
| jg    | 0100 LLLL LLLL LLLL   | Jump if greater than               |
| jge   | 0101 LLLL LLLL LLLL   | Jump if greater or equal           |
| jz    | 0110 LLLL LLLL LLLL   | Jump if last value is zero         |

### Movs
| inst  |        OpCode         |           Description              |
| ----- | --------------------- | ---------------------------------- |
| movcosnt   | 1000 AAAA cccc cccc | A = C                           |
| load  | 1001 0001 AAAA [BBBB] | A = *B                             |
| store | 1001 0010 [AAAA] BBBB | *A = B                             |
| mov   | 1001 0011 AAAA BBBB   | A = B                              |
| push  | 1001 0100 AAAA XXXX   | Put value A on the stack           |
| pop   | 1001 0101 AAAA XXXX   | Remove value from stack            |

### Compare
| inst  |        OpCode         |           Description              |
| ----- | --------------------- | ---------------------------------- |
| cmp   | 1100 XXXX AAAA BBBB   | Compare A with B                   |
| cmpcosnt  | 1110 AAAA cccc cccc | Compare A with C                 |

### Functions
| inst  |        OpCode         |           Description              |
| ----- | --------------------- | ---------------------------------- |
| call  | 1010 LLLL LLLL LLLL   | Call a function                    |
| ret   | 1011 XXXX XXXX XXXX   | Return a function                  |

### Others
| inst  |        OpCode         |           Description              |
| ----- | --------------------- | ---------------------------------- |
| nop   | 0000 XXXX XXXX XXXX   | Does not do anything               |
