| inst | OpCode | Description | Implemented |
| ---- | ------ | ----------- | ----------- |
| nop  | 0000 XXXX XXXX XXXX | Does not do anything | [OK] |
| and  | 1111 0000 aaaa bbbb | A = A & B | [OK] |
| sub  | 1111 0001 aaaa bbbb | A = A - B | [OK] |
| imult  | 1111 0010 aaaa bbbb | A = A * B | [OK] |
| idiv  | 1111 0011 aaaa bbbb | A = A / B | [OK] |
| nand  | 1111 0100 aaaa bbbb | A = !(A & B) | [OK] |
| rsh  | 1111 0101 aaaa bbbb | A = A >> B | [OK] |
| xnor  | 1111 0110 aaaa bbbb | A = !(A ^ B) | [OK] |
| inc  | 1111 0111 aaaa xxxx | A = A + 1 | [OK] |
| dec  | 1111 1000 aaaa xxxx | A = A - 1 | [OK] |
| xor  | 1111 1001 aaaa bbbb | A = A ^ B | [OK] |
| not  | 1111 1010 aaaa bbbb | A = !A | [OK] |
| nor  | 1111 1011 aaaa bbbb | A = !(A \| B) | [OK] |
| lsh  | 1111 1100 aaaa bbbb | A = A << B | [OK] |
| add  | 1111 1101 aaaa bbbb | A = A + B | [OK] |
| ivt  | 1111 1110 aaaa bbbb | A = -A | [OK] |
| or  | 1111 1111 aaaa bbbb | A = A \| B | [OK] |

<details open>
<summary>Legend</summary>

* AAAA = Address of an A register
* BBBB = Address of an B register
* XXXX = Will be ignored
* CCCC CCCC = 8 bit C constant
* LLLL LLLL LLLL = Label used for jumps in 12-bit code

</details>
